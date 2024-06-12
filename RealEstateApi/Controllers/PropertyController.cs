namespace RealEstate.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;

    [Route("api/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("all")]
        public async Task<IActionResult> GetAllProperties([FromQuery] string saleCategory = "Rent", [FromQuery] string propertyCateogry = "Apartment")
        {
            var result = await _propertyService.GetAllPropertiesByCategoryAsync(propertyCateogry, saleCategory);

            return Ok(result);
        }
    }
}
