using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrbitalController : ControllerBase
    {
        Performer performer = new();

        ILogger<OrbitalController> logger;

        public OrbitalController(ILogger<OrbitalController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("initial")]
        public async Task<OrbitalForecastConditionNumber> GetInitialConditions()
        {
            var result = await performer.GetInitialAsync();
            return result;
        }

        [HttpPost(Name = "forecastfromnumber")]
        public async Task<OrbitalForecastItemNumber[]> PostForecastFromNumber([FromBody] OrbitalForecastConditionNumber condition)
        {

            if (condition == null || condition.Begin >= condition.End)
            {
                return Enumerable.Empty<OrbitalForecastItemNumber>().ToArray();
            }
            var result = await performer.CalculateOrbitalForecastFromNubmerAsync(condition, HttpContext.RequestAborted);
            if (result == null || !result.Any())
            {
                return Enumerable.Empty<OrbitalForecastItemNumber>().ToArray();
            }
            return result.ToArray();

        }

/*
        [HttpPost(Name = "forecastfromnumber")]
        [EnableCors("CorsPolicy")]
        public async Task<OrbitalForecastItemNumber[]> PostOrbitalForecastFromNumber([FromBody] OrbitalForecastConditionNumber condition)
        {

            if (condition == null || condition.Begin >= condition.End)
            {
                return Enumerable.Empty<OrbitalForecastItemNumber>().ToArray();
            }
            var result = await performer.CalculateOrbitalForecastFromNubmerAsync(condition, HttpContext.RequestAborted);
            if (result == null || !result.Any())
            {
                return Enumerable.Empty<OrbitalForecastItemNumber>().ToArray();
            }
            return result.ToArray();
    
        }

        [HttpPost(Name = "myPostRoute")]  // Names the route "myPostRoute" for URL generation
        [EnableCors("CorsPolicy")] // Apply the CORS policy
        public IActionResult PostData([FromBody] MyData data)
        {
            if (data == null)
            {
                return BadRequest("Data cannot be null.");
            }

            // Process the incoming data (e.g., save to a database)
            // In this example, we're just logging the data

            Console.WriteLine($"Received data: Value = {data.Value}");

            // Return a success response
            return Ok(new { Message = "Data received successfully", ReceivedValue = data.Value });
        }
        public class MyData
        {
            public string? Value { get; set; } // Use nullable string to allow for null values during deserialization
        }*/

    }

}
