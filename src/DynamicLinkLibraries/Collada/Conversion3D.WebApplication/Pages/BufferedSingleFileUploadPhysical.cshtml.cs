using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Conversion3D.WebApplication.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace Conversion3D.WebApplication.Pages
{
    public class BufferedSingleFileUploadPhysicalModel : PageModel
    {
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".obj", ".ac", ".dae" };

        private readonly Dictionary<string, string[]> fileTypes = new Dictionary<string, string[]>()
            { 
            { "AC3D file format", new string[] {".ac", "ac3d"} },
           { "Obj file format",  new string[] { ".obj" }},
           { "Collada file format",  new string[] { ".dae" }}
            };

        private readonly string _targetFilePath;

        public BufferedSingleFileUploadPhysicalModel(IConfiguration config)
        {
            var l = new List<string>();
            var lt = new List<string>();
            foreach (var p in fileTypes)
            {
                foreach (var item in p.Value)
                {
                    l.Add(item);
                }
               lt.Add("  " + p.Key);
//                Extensions.Add(new SelectListItem { Value = k, Text = k });
            }

            Extensions = lt.ToArray();


            _permittedExtensions = l.ToArray();
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }

        [Required]
        [Display(Name = "Extensions")]

        public List<SelectListItem> Extensions1 { get; } = new List<SelectListItem>();
 /*   {
        new SelectListItem { Value = ".ac", Text = "obj files" },
        new SelectListItem { Value = ".obj", Text = "ac files" },
        new SelectListItem { Value = ".dae", Text = "Collada"  },
    };*/
  //      [Display(Name = "Extension")]
  //      [StringLength(50, MinimumLength = 0)]
        [BindProperty]
        public string Extension
        {
            get;
            set;
        }
        public string[] Extensions;// = new[] { "Male", "Female", "Unspecified" };




        [BindProperty]
        public BufferedSingleFileUploadPhysical FileUpload 
        { 
            get; 
            set; 
        }

        public string Result { get; private set; }

        public void OnGet()
        {
       
        }

        public void OnPost()
        {

        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }
            var ext = fileTypes[Extension.Substring(2)][0];
            



            var formFileContent =
                await FileHelpers.ProcessFormFile<BufferedSingleFileUploadPhysical>(
                    FileUpload.FormFile, ModelState, _permittedExtensions,
                    _fileSizeLimit, ext);

            var ms = ModelState;
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }


            // For the file name of the uploaded file stored
            // server-side, use Path.GetRandomFileName to generate a safe
            // random file name.
            var trustedFileNameForFileStorage = Path.GetRandomFileName();
            var filePath = Path.Combine(
                _targetFilePath, trustedFileNameForFileStorage);

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.

            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with a FormFile, use the following
                // instead:
                //await FileUpload.FormFile.CopyToAsync(fileStream);
            }

            return RedirectToPage("./Index");
        }
    }

    public class BufferedSingleFileUploadPhysical
    {
        private string note = "Image";

        public BufferedSingleFileUploadPhysical()
        {

        }

        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile 
        { 
            get; 
            set; 
        }

    }
}
