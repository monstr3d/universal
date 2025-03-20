using Conversion3D.WebApplication.Interfacers;
using Conversion3D.WebApplication.Pages.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Conversion3D.WebApplication.Pages
{
    [AllowAnonymous]
    public class HyperLink1Model : PageModel
    {

        public HyperLink1Model(IHyperLinkTransient hyperLink)
        {
            Data = hyperLink.Tuple.Item1;
          //  Data = new MemoryStream(bytesSingleton.Tuple.Item1);
          //  Data.Position = 0;
            FileName = hyperLink.Tuple.Item2;
    //        Bytes = bytesSingleton.Tuple.Item1;
    //        F = bytesSingleton.Tuple.Item2;
        }

        public byte[] Bytes
        {
            get;
            private set;
        }

        public string F { get; private set; }


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
          //  await Task.Delay(1);
            //  Data.Position = 0;
              return File(Data, "application/zip", FileName + ".zip");
            //var stream = new MemoryStream(Bytes);
          //  return File(Data, "application/zip", F + ".zip");
        }
    }
}