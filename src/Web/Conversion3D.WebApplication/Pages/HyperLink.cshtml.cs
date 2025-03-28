using Conversion3D.WebApplication.Interfacers;
using Conversion3D.WebApplication.Pages.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Conversion3D.WebApplication.Pages
{
    [AllowAnonymous]
    public class HyperLinkModel : PageModel
    {

        public HyperLinkModel(IBytesSingleton hyperLink)
        {
           // Data = hyperLink.Tuple.Item1;
            FileName = hyperLink.Tuple.Item2;
            Bytes = hyperLink.Tuple.Item1;
        }

        
         public Stream Data
        {
            get;
            private set;
        }

        public string FileName
        {
            get;
            private set;
        }

        public byte[] Bytes
            { get; private set; }
        

    
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
            // Data.Position = 0;
            var data = new MemoryStream(Bytes);
            data.Position = 0;
            return File(data, "application/zip", FileName + ".zip");
        }

  
    }
}
