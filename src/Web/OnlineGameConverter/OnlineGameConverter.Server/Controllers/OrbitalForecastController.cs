using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.BusinessLogic.Orbital;
using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrbitalForecastController : Controller
    {

        [HttpGet]
        public async Task<IEnumerable<OrbitalForecastItem>> GetOrbitalForecast(OrbitalForecastCondition condition)
        {
            if (condition == null || condition.Begin >= condition.End)
            {
                return Enumerable.Empty<OrbitalForecastItem>();
            }
            var performer = new Performer();
            var result = await performer.CalculateAsync(condition, HttpContext.RequestAborted);
            if (result == null || !result.Any())
            {
                return Enumerable.Empty<OrbitalForecastItem>();
            }
            return result;
            /* !!! GENERATED return result.Select(item => new OrbitaForecastItem(
                item.DateTime,
                item.X,
                item.Y,
                item.Z,
                item.Vx,
                item.Vy,
                item.Vz
            ));*/


        }
    }
}
