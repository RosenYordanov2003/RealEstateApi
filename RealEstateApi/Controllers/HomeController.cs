namespace RealEstate.Controllers
{
    using System.IO;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using Core.Queries.Cities;
    using Core.Queries.Properties;
    using Core.Queries.PropertyCategories;
    using Core.Queries.SaleCategories;
    using Core.Models.Property;
    using Core.Commands.Amenities;

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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("properties")]
        public async Task<IActionResult> GetAllProperties([FromQuery] FilterPropertyModel filterModel)
        {
            var properties = await _mediator.Send(new GetFilteredPropertiesQuery(filterModel));

            return Ok(properties);
        }

        [HttpGet]
        [Route("GetJson")]
        public async Task<IActionResult> GetJson()
        {
            string csvOutputFilePath = "C:\\Users\\Home\\source\\repos\\RealEstateApi\\RealEstateApi\\schools.csv";
            string jsonData = await System.IO.File.ReadAllTextAsync("C:\\Users\\Home\\source\\repos\\RealEstateApi\\RealEstateApi\\schools.json");
            var jsonObject = JObject.Parse(jsonData);
            var elements = jsonObject["elements"];

            using (var writer = new StreamWriter(csvOutputFilePath))
            {
                writer.WriteLine("name,latitude,longitude");

                foreach (var element in elements)
                {
                    var tags = element["tags"];
                    string? name = tags?["name"]?.ToString();

                    if (!string.IsNullOrEmpty(name))
                    {
                        name = name.Replace(',', ' ');
                        string lat = element["lat"]?.ToString() ?? "";
                        string lon = element["lon"]?.ToString() ?? "";

                       
                        if (element["type"].ToString() == "way")
                        {
                            var geometry = element["geometry"];
                            if (geometry != null && geometry.HasValues)
                            {
                                lat = geometry.First["lat"]?.ToString() ?? "";
                                lon = geometry.First["lon"]?.ToString() ?? "";
                            }
                        }

                        writer.WriteLine($"{name},{lat},{lon}");
                    }
                }
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> InsertSchoolAmenities()
        {
            const string csvPath = "C:\\Users\\Home\\source\\repos\\RealEstateApi\\RealEstateApi\\schools.csv";
            const int amenityCategoryId = 1;

            await _mediator.Send(new InsertAmenitiesCommand(csvPath, amenityCategoryId));

            return Ok();
        }
    }
}
