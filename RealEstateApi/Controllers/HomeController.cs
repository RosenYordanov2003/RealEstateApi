using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Queries.Properties;

namespace RealEstate.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
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
    }
}
