using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Trading.Library.Classes;
using Trading.Library.Objects;
using Trading.Library;

namespace OnlineGameConverter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradingOKController : Controller
    {
        // Java  Client   ASP Cancellation Token Android


        /// <summary>
        /// Task<IActionResult>  Java client   Cancel request
        /// </summary>

        ILogger<TradingOKController> logger;

        DataQuery query;

        public TradingOKController(ILogger<TradingOKController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("symbols")]
        public async Task<IActionResult> GetSymbols(CancellationToken token)
        {
            var t = await StaticExtensionTradingLibrary.GetTradingHistorucalSrtingSymbolsArray(token);

            return Ok(t);
        }

        [HttpPost]
        public async Task<List<HistoricalDataMessageNumber>> GetHistory([FromBody] DataQueryInit init,
            CancellationToken token)
        {
            var query = await DataQuery.Create(init, token);
            var dt = await query.GetHistoricalDataMessageDateTimes(token);
            var s = from hist in dt select hist.Convert();
            return s.ToList();
        }
    }
}
