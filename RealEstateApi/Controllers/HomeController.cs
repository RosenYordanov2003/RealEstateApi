﻿namespace RealEstate.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Core.Queries.Cities;
    using Core.Queries.Properties;
    using Core.Queries.PropertyCategories;
    using Core.Queries.SaleCategories;

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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _mediator.Send(new GetCitiesQuery());

            return Ok(cities);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("saleCategories")]
        public async Task<IActionResult> GetSalesCategories()
        {
            var salesCategories = await _mediator.Send(new GetSaleCategoriesQuery());

            return Ok(salesCategories);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("propertyCategories")]
        public async Task<IActionResult> GetPropertyCategories()
        {
            var propertyCategories = await _mediator.Send(new GetPropertyCategoriesQuery());

            return Ok(propertyCategories);
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
