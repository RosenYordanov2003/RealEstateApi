namespace RealEstate.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using MediatR;
    using RealEstate.Core.Queries;

    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropertyController(IPropertyService propertyService, IMediator mediator)
        {
            _propertyService = propertyService;
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
    }
}
