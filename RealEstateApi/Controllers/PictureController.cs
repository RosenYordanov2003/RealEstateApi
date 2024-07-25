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

    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UploadPropertyImg([FromForm] UploadPropertyPictureModel model)
        {
            if (!await _mediator.Send(new CheckIfPropertyExistsQuery(model.PropertyId)))
            {
                return NotFound(new BaseResponseModel("property does not exist", false));
            }
            if(!await _mediator.Send(new CheckIfPropertyIsAlreadyOwnedByUserQuery(model.PropertyId, model.UserId)))
            {
                return BadRequest(new BaseResponseModel("User isn't owning that property", false));
            }
            await _mediator.Send(new CreatePictureCommand(_webHostEnvironment.WebRootPath, model.File, model.PropertyId));

            return Ok();
        }
    }
}
