﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Queries.Cities;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _mediator.Send(new GetCitiesQuery());

            return Ok(cities);
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
