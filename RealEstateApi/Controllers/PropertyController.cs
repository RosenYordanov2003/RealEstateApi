namespace RealEstate.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Core.Queries.Properties;
    using RealEstate.Core.Queries.Users;

    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("all")]
        public async Task<IActionResult> GetAllProperties([FromQuery] string saleCategory = "Rent", [FromQuery] string propertyCateogry = "Apartment")
        {

            var result = await _mediator.Send(new GetTopTenPropertiesQuery(propertyCateogry, saleCategory));

            return Ok(result);
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
    }
}
