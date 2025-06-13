using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace QandA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
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

    }
}
