using Conversion3D.WebApplication.Pages.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Conversion3D.WebApplication.Pages
{
    [AllowAnonymous]
    public class HyperLinkModel : PageModel
    {

        public HyperLinkModel(IHyperLinkTransient hyperLink)
        {
            Data = hyperLink.Tuple.Item1;
            FileName = hyperLink.Tuple.Item2;
        }

        
         public byte[] Data
        {
            get;
            private set;
        }

        public string FileName
        {
            get;
            private set;
        }
        

    
        public string Text
        {
            get;
            set;
        }

        public void OnGet()
        {
        }

        

        public async Task<IActionResult> OnPostDownloadAsync()
        {
            await Task.Delay(1);
            return File(Data, "application/xml", FileName);
        }

  
    }
}
