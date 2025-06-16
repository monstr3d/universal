using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrbitalController : ControllerBase
    {
        Performer performer = new();

        public OrbitalController()
        {

        }

        [HttpGet("initial")]
        public async Task<OrbitalForecastConditionNumber> GetInitial()
        {
            var result = await performer.GetInitialAsync();
            return result;
        }


        [HttpPost(Name = "forecastfromnumber")]
        public async Task<OrbitalForecastItemNumber[]> GetOrbitalForecastFromNumber([FromBody] OrbitalForecastConditionNumber condition)
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

    }

}
