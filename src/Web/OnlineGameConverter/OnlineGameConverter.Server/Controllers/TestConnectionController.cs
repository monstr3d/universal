using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.Classes;
using System.Text;

namespace OnlineGameConverter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConnectionController : ControllerBase
    {

        ILogger<TestConnectionController> logger;

        public TestConnectionController(ILogger<TestConnectionController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("test")]
        public async Task<string> GetTest(CancellationToken token)
        {
            var t = await Task.FromResult(Test);
            return t();
        }

        string Test() => "test";
   
    }
}
