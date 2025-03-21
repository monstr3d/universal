using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Conversion3D.WebApplication.Pages
{
    public class Upload3DMultipleModel : PageModel
    {
        public void OnGet()
        {
        }

       
        public IFormFileCollection FormFiles { get; set; }
    }
}
