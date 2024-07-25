﻿namespace RealEstate.Controllers
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
            await _mediator.Send(new CreatePictureCommand(_webHostEnvironment.WebRootPath, model.File, model.PropertyId));

            return Ok();
        }

        [HttpGet("{id}")]
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
    }
}
