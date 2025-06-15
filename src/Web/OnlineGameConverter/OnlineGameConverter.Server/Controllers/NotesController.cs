using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OnlineGameConverter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        public NotesController()
        {

        }
        ExtendedNote GetE(Note note)
        {
            return new ExtendedNote { DateTime = DateTime.Now.ToString(), Name = note.Name, Description = note.Description };
        }

        Task<ExtendedNote> GetEAsync(Note note)
        {
            return Task.FromResult(GetE(note));
        }

        [HttpPost]
        public Task<ExtendedNote> GetExtendedNote([FromBody] Note note)
        {
            return GetEAsync(note);
        }
        
        [HttpPost("fiction")]
        public Task<ExtendedNote> GetFictionNote([FromBody] Note note)
        {
            return GetEAsync(note);
        }

    }
}
