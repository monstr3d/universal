using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Conversion3D.WebApplication.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conversion3D.WebApplication.Pages
{
    public class Upload3DModel : PageModel
    {
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".obj", ".ac", ".dae" };

        private readonly Dictionary<string, Tuple<string[], string>> fileTypes = new Dictionary<string, Tuple<string[], string>>()
            {
            { "AC3D file format", new Tuple<string[], string>(new string[] {".ac", "ac3d"}, null) },
           { "Obj file format",  new  Tuple<string[], string>(new string[] { ".obj" }, null)},
           { "Collada 1.4 file format", new Tuple<string[], string>( new string[] { ".dae" }, null)},
             { "Collada 1.5 file format", new Tuple<string[], string>( new string[] { ".dae" }, "1.5.0")}
          };

        private readonly string _targetFilePath;

        public Upload3DModel(IConfiguration config)
        {
            var l = new List<string>();
            var lt = new List<string>();
            foreach (var p in fileTypes)
            {
                foreach (var item in p.Value.Item1)
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
        public Upload3D FileUpload
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
            var ext = fileTypes[Extension.Substring(2)];




            var formFileContent =
                await FileHelpers.ProcessFormFile<Upload3D>(
                    FileUpload.FormFile, ModelState, _permittedExtensions,
                    _fileSizeLimit);

            var ms = ModelState;
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            var inex = FileUpload.FormFile.FileName;

            using (var stream = new MemoryStream(formFileContent))
            {
                var creator = inex.ToMeshCreator(stream);
                var p = new Performer();
                var converter = ext.Item1[0].ToMeshConvertor(ext.Item2);
                var res = p.Create<object>(creator.Meshes, converter);
                var sr = converter as IStringRepresentation;
                var r = sr.ToString(sr);
            }

            /*
                        var creator = ext.ToMeshCreator();
                        var mesh = creator
                        var converter = ".dae".ToMeshConvertor("1.5.0"); // new Collada150.Collada150Converter();
                        var p = new Performer();
                        var res = p.Create<object>(creator, converter);
                        if (converter is IStringRepresentation sr)
                        {
                            return sr.ToString(res);
                        }

                        var obj = Generate<object>(filename, ac);

            */
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

    public class Upload3D
    {
        private string note = "Image";

        public Upload3D()
        {

        }

        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile
        {
            get;
            set;
        }


        string Convert(byte[] bytes, string filaname)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var meshCreator = filaname.ToMeshCreator(stream);
                return null;

            }
        }
    }
}
