﻿namespace RealEstate.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Core.Queries.Properties;
    using Core.Queries.Users;
    using Responses.Properties;
    using Core.Commands;
    using Core.Models.Property;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using RealEstate.Data.Data.Models;

    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        public PropertyController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetProperty(Guid Id)
        {
            bool result = await _mediator.Send(new CheckIfPropertyExistsQuery(Id));

            if (!result)
            {
                return BadRequest();
            }
            var propertyModel = await _mediator.Send(new GetPropertyByIdQuery(Id));
            return Ok(propertyModel);
        }

        [HttpGet("getUserProperties{userId}")]
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
            var username = (User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = await _userManager.FindByNameAsync(username);

            bool isOwnedByUser = await _mediator.Send(new CheckIfUserOwnsPropertyQuery(user.Id, propertyId));
            if (!isOwnedByUser)
            {
                return BadRequest(new PropertyBaseResponseModel(false, "User dosen't own that property"));
            }

            await _mediator.Send(new DeletePropertyCommand(propertyId));

            return Ok(new PropertyBaseResponseModel(true, null));
        }
    }
}
