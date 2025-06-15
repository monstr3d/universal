using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrbitalController : ControllerBase
    {
        public OrbitalController()
        {

        }

        Performer performer = new();
/*        private readonly ILogger<FController> _logger;

        public FController(ILogger<FController> logger)
        {
            _logger = logger;
            var ff = this.ControllerContext;
        }
*/

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

        ExtendedNote GetE(Note note)
        {
            return new ExtendedNote { DateTime = DateTime.Now.ToString(), Name = note.Name, Description = note.Description };
        }

        Task<ExtendedNote> GetEAsync(Note note)
        {
            return Task.FromResult(GetE(note));
        }



        [HttpPost("GetExtendedNote")]
        public Task<ExtendedNote> GetExtendedNote([FromBody] Note note)
        {
            return GetEAsync(note);
        }


        /*

        public async Task<OrbitalForecastItemString[]> GetOrbitalForecast([FromBody] OrbitalForecastConditionString condition)
        {

          
            var result = await performer.CalculateOrbitalForecastFromStringAsync(condition, HttpContext.RequestAborted);
            if (result == null || !result.Any())
            {
                return Enumerable.Empty<OrbitalForecastItemString>().ToArray();
            }
            return result.ToArray();

        }
        */
    }

}
