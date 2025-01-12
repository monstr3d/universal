using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Conversion3D.WebApplication.Pages
{
    public class HyperLinkModel : PageModel, IHyperLink
    {
/*
        public HyperLinkModel(ILogger<PrivacyModel> logger)
        {

        }


        public HyperLinkModel(IConfiguration config)
        {

        }
*/
        public HyperLinkModel()
        {
            var vd = ViewData;
        }

        public void OnGet()
        {
        }

        public Tuple<byte[], string> Tuple
        {
            get;
            set;
        }
    }
}
