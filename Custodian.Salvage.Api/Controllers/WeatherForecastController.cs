using Custodian.Salvage.DomainFacade.services;
using Microsoft.AspNetCore.Mvc;

namespace Custodian.Salvage.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPurchaseManager _purchaseManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPurchaseManager pm)
        {
            _logger = logger;
            _purchaseManager = pm;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public IActionResult GetBidItems()
        {
            var lst = _purchaseManager.GetBidItems();

            return StatusCode(200, lst.ToArray());
        }
    }
}