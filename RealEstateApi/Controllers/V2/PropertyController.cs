﻿namespace RealEstate.Controllers.V2
{
    using Asp.Versioning;
    using MediatR;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Commands.Pictures;
    using Core.Commands.Properties;
    using Core.Models.Property;
    using Core.Queries.Properties;
    using Core.Queries.Users;
    using Extensions;
    using Responses.Properties;


    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PropertyController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetProperty()
        {
            return Ok("Hello");
        }
        [HttpGet("user{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserProeprties([FromRoute] Guid userId)
        {
            bool result = await _mediator.Send(new CheckIfUserExistsByIdQuery(userId));
            if (!result)
            {
                return NotFound();
            }
            var properties = await _mediator.Send(new GetUserPropertiesQuery(userId));
            return Ok(properties);
        }

        [HttpPost]
        [Route("addToFavorite")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> AddPropertyToUserFavortie([FromQuery] Guid userId, [FromQuery] Guid propertyId)
        {
            bool isUserExists = await _mediator.Send(new CheckIfUserExistsByIdQuery(userId));
            if (!isUserExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "User does not exist"));
            }
            bool isPropertyExists = await _mediator.Send(new CheckIfPropertyExistsQuery(propertyId));
            if (!isPropertyExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "Property does not exist"));
            }
            await _mediator.Send(new AddPropertyToUserFavoriteCommand(new AddPropertyToUserFavoritesModel(userId, propertyId)));
            return Created("/getUserProperties", new PropertyBaseResponseModel(true, " "));
        }

        [HttpGet]
        [Route("userFavorite {userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetUserFavoriteProperties([FromRoute] Guid userId)
        {
            bool isUserExists = await _mediator.Send(new CheckIfUserExistsByIdQuery(userId));
            if (!isUserExists)
            {
                return NotFound("User does not exist");
            }
            var properties = await _mediator.Send(new GetUserFavoritePropertiesQuery(userId));
            return Ok(properties);
        }

        [HttpPost]
        [Route("removeFromFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> RemoveFromUserFavorite(Guid userId, Guid propertyId)
        {
            bool isUserExists = await _mediator.Send(new CheckIfUserExistsByIdQuery(userId));
            if (!isUserExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "User does not exist"));
            }
            bool isPropertyExists = await _mediator.Send(new CheckIfPropertyExistsQuery(propertyId));
            if (!isPropertyExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "Property does not exist"));
            }
            await _mediator.Send(new RemoveProeprtyFromUserFavoriteCommand(new AddPropertyToUserFavoritesModel(userId, propertyId)));

            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        [Route("delete {propertyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteProperty([FromRoute] Guid propertyId)
        {
            bool isPropertyExists = await _mediator.Send(new CheckIfPropertyExistsQuery(propertyId));
            if (!isPropertyExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "Property does not exist"));
            }
            string username = User.GetUserName();
            Guid userId = await _mediator.Send(new GetUserIdQuery(username));

            bool isOwnedByUser = await _mediator.Send(new CheckIfUserOwnsPropertyQuery(userId, propertyId));
            if (!isOwnedByUser)
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User dosen't own that property"));
            }

            await _mediator.Send(new DeletePropertyCommand(propertyId));

            return Ok(new PropertyBaseResponseModel(true, null));
        }

        [HttpPatch]
        [Route("recover {propertyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecoverProperty([FromRoute] Guid propertyId)
        {
            bool isPropertyExists = await _mediator.Send(new CheckIfPropertyExistsQuery(propertyId));
            if (!isPropertyExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "Property does not exist"));
            }
            string username = User.GetUserName();
            Guid userId = await _mediator.Send(new GetUserIdQuery(username));

            bool isOwnedByUser = await _mediator.Send(new CheckIfUserOwnsPropertyQuery(userId, propertyId));
            if (!isOwnedByUser)
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User dosen't own that property"));
            }
            await _mediator.Send(new RecoverPropertyCommand(propertyId));

            return Ok(new PropertyBaseResponseModel(true, null));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("airbnb")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Rent([FromBody] BookPropertyModel model)
        {
            bool isPropertyExists = await _mediator.Send(new CheckIfPropertyExistsQuery(model.Id));
            if (!isPropertyExists)
            {
                return NotFound(new PropertyBaseResponseModel(false, "Property does not exist"));
            }

            const int airbnbCategoryId = 1;

            bool propertyCategoryIsForRent = await _mediator.Send(new CheckPropertyCategoryQuery(model.Id, airbnbCategoryId));
            if (!propertyCategoryIsForRent)
            {
                return BadRequest(new PropertyBaseResponseModel(false, "Property is not for rent"));
            }

            bool isAvailableForPeriod = await _mediator.Send(new CheckIfPropertyIsRentedQuery(model));

            if (!isAvailableForPeriod)
            {
                return BadRequest(new PropertyBaseResponseModel(false, "Property is already rented for that period"));
            }
            Guid userId = await _mediator.Send(new GetUserIdQuery(User.GetUserName()));
            await _mediator.Send(new BookPropertyCommand(model, userId));

            return Ok(new PropertyBaseResponseModel(true, null));
        }

        [HttpPatch]
        [Route("edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit([FromBody] EditPropertyModel model, [FromQuery] Guid id)
        {
            bool isPropertyExists = await _mediator.Send(new CheckIfPropertyExistsQuery(id));
            string username = User.GetUserName();

            if (!isPropertyExists || string.IsNullOrWhiteSpace(username))
            {
                return NotFound(new PropertyBaseResponseModel(false, "Property or User do not exist"));
            }
            Guid userId = await _mediator.Send(new GetUserIdQuery(username));

            bool isOwnedByUser = await _mediator.Send(new CheckIfUserOwnsPropertyQuery(userId, id));
            if (!isOwnedByUser)
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User dosen't own that property"));
            }

            await _mediator.Send(new EditPropertyCommand(model, id));

            return Ok(new PropertyBaseResponseModel(true, null));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Create([FromForm] CreatePropertyModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(new PropertyBaseResponseModel(false, string.Join(" ", errors)));
            }
            string username = User.GetUserName();
            Guid userId = await _mediator.Send(new GetUserIdQuery(username));
            Guid id = await _mediator.Send(new CreatePropertyCommand(model, userId));


            foreach (var file in model.Files)
            {
                await _mediator.Send(new CreatePictureCommand(_webHostEnvironment.WebRootPath, file, id));
            }
            PropertyDetailsModel detailsModel = await _mediator.Send(new GetPropertyByIdQuery(id));
            return CreatedAtRoute("details", new { Id = id }, detailsModel);
        }
    }
}
