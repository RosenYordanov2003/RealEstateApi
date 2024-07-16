namespace RealEstate.Controllers
{
    using System.IO;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Core.Queries.Cities;
    using Core.Queries.Properties;
    using Core.Queries.PropertyCategories;
    using Core.Queries.SaleCategories;
    using RealEstate.Core.Models.Property;
    using Newtonsoft.Json.Linq;

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
            string csvOutputFilePath = "C:\\Users\\Home\\source\\repos\\RealEstateApi\\RealEstateApi\\schools.csv"; // Заменете с пътя към вашия CSV изходен файл


            string jsonData = await System.IO.File.ReadAllTextAsync("C:\\Users\\Home\\source\\repos\\RealEstateApi\\RealEstateApi\\schools.json");
            var jsonObject = JObject.Parse(jsonData);
            var elements = jsonObject["elements"];

            using (var writer = new StreamWriter(csvOutputFilePath))
            {
                // Записване на заглавката в CSV файла
                writer.WriteLine("name,latitude,longitude");

                foreach (var element in elements)
                {
                    var tags = element["tags"];
                    if (tags != null && tags["name"] != null)
                    {
                        string name = tags["name"].ToString();
                        string lat = element["lat"]?.ToString() ?? "";
                        string lon = element["lon"]?.ToString() ?? "";

                        writer.WriteLine($"{name},{lat},{lon}");
                    }
                }
            }

            Console.WriteLine("Конвертирането завърши успешно.");
            return Ok();
        }
    }
}
