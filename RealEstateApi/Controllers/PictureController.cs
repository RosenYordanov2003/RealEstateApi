namespace RealEstate.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Core.Commands.Pictures;
    using Core.Models.Pictures;
    using Core.Queries.Properties;
    using Responses;
    using Core.Queries.Pictures;
    using Core.Queries.Users;
    using Extensions;
    using Responses.Pictures;
    using CsvHelper.Configuration.Attributes;

    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/pictures")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMediator _mediator;

        public PictureController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
        {
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("upload-property")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UploadPropertyImg([FromForm] UploadPropertyPictureModel model)
        {
            if (!await _mediator.Send(new CheckIfPropertyExistsQuery(model.PropertyId)))
            {
                return NotFound(new BaseResponseModel("property does not exist", false));
            }

            Guid userId = await _mediator.Send(new GetUserIdQuery(User.GetUserName()));

            if(!await _mediator.Send(new CheckIfPropertyIsAlreadyOwnedByUserQuery(model.PropertyId, userId)))
            {
                return BadRequest(new BaseResponseModel("User isn't owning that property", false));
            }
            PictureModel pictureModel = await _mediator.Send(new CreatePictureCommand(_webHostEnvironment.WebRootPath, model.File, model.PropertyId));

            return CreatedAtRoute(nameof(GetById), new {id = pictureModel.Id}, pictureModel);
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!await _mediator.Send(new CheckIfPictureExistsByIdQuery(id)))
            {
                return NotFound(new BaseResponseModel("Picture does not exist", false));
            }

            var model = await _mediator.Send(new GetPictureByIdQuery(id));

            return Ok(new PictureResponseModel("", true, model));
        }

        [HttpDelete]
        [Route("remove-proeprty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RemovePropertyImg([FromBody] DeletePropertyPictureModel model)
        {
            if (!await _mediator.Send(new CheckIfPropertyExistsQuery(model.PropertyId)))
            {
                return NotFound(new BaseResponseModel("property does not exist", false));
            }
            if (!await _mediator.Send(new CheckIfPictureExistsByIdQuery(model.PictureId)))
            {
                return NotFound(new BaseResponseModel("Picture does not exist", false));
            }

            Guid userId = await _mediator.Send(new GetUserIdQuery(User.GetUserName()));

            if (!await _mediator.Send(new CheckIfPropertyIsAlreadyOwnedByUserQuery(model.PropertyId, userId)))
            {
                return BadRequest(new BaseResponseModel("User isn't owning that property", false));
            }

            PictureModel pictureModel = await _mediator.Send(new GetPictureByIdQuery(model.PictureId));

            string imgFileName = pictureModel.ImgUrl.Split("/", StringSplitOptions.RemoveEmptyEntries).Last();

            string webRoothPath = _webHostEnvironment.WebRootPath;

            await _mediator.Send(new DeletePictureCommand(webRoothPath, pictureModel.Id, imgFileName));

            return Ok(new BaseResponseModel("You have successfully deleted a picture", true));
        }

    }
}
