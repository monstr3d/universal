using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.BusinessLogic.Orbital;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrbitalForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OrbitalForecastController> _logger;

        public OrbitalForecastController(ILogger<OrbitalForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrbitalForecast")]
        public IEnumerable<OrbitalForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new OrbitalForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
