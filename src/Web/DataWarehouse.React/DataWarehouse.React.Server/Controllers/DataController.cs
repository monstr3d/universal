using DataWarehouse.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace DataWarehouse.React.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {

        [HttpPost]
        public IDirectory CreateDirectory(object id, IDirectory dir)
        {
            return null;
        }

        [HttpPatch]
        public void UpdateDirectory(IDirectory dir)
        {

        }

        [HttpGet("@{id}")]
        public IDirectory Create(object id, IDirectory dir)
        {
            return null;
        }


        [HttpGet("@{id}")]
        public IEnumerable<IDirectory> GetDirectories(object id)
        {
            return null;
        }

        [HttpGet]
        public IEnumerable<IDirectory> GetRoots()
        {
            return null;
        }

        [HttpDelete("@{id}")]
        public IDirectory Delete(object id)
        {
            return null;
        }

    }
}
