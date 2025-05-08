using Abstract3DConverters;
using OnlineGameConverter.Server.Classes;
using OnlineGameConverter.Server.Interfaces;
using OnlineGameConverter.Server.Utilites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace OnlineGameConverter.Server.Pages
{
    public class Upload3DModel : PageModel
    {
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".obj", ".ac", ".dae" };

        private readonly Dictionary<string, Tuple<string[], string>> fileTypes = new Dictionary<string, Tuple<string[], string>>()
            {
            { "AC3D file format", new Tuple<string[], string>(new string[] {".ac", "ac3d"}, null) },
           { "Obj file format",  new  Tuple<string[], string>(new string[] { ".obj" }, null)},
           { "Collada 1.4 file format", new Tuple<string[], string>( new string[] { ".dae" }, "1.4.1")},
             { "Collada 1.5 file format", new Tuple<string[], string>( new string[] { ".dae" }, "1.5.0")},
           { "WPF XAML file format", new Tuple<string[], string>([ ".xaml" ], null)}
          };

        private readonly string _targetFilePath;

        private IBytesSingleton HyperLink { get; set; }

        private IExceptionSingleton ExceptionSingleton { get; set; }

        private IHttpContextAccessor httpContextAccessor;

        

        public Upload3DModel(IConfiguration config, IBytesSingleton hyperLink, IExceptionSingleton exceptionSingleton, IHttpContextAccessor httpContextAccessor)
        {
            HyperLink = hyperLink;
            Tuple = hyperLink.Tuple;
            ExceptionSingleton = exceptionSingleton;
            this.httpContextAccessor = httpContextAccessor;
            var c = httpContextAccessor.HttpContext.Request.Cookies;
            if (c.ContainsKey("dir"))
            {
                var dir = c["dir"];
                Directory = dir;
            }
            if (c.ContainsKey("inputdir"))
            {
                var dir = c["inputdir"];
                InputDirectory = dir;
            }

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
            _fileSizeLimit =  config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }


        public async Task<IActionResult> OnPostDownloadAsync()
        {
            await Task.Delay(1);
            var data = new MemoryStream(Tuple.Item1);
            data.Position = 0;
            return File(data, "application/zip", Tuple.Item2 + ".zip");
        }

        public Tuple<byte[], string, string> ? Tuple
        {
            get;
            set;
        }

       [BindProperty]
        public string Extension
        {
            get;
            set;
        }

        public string[] Extensions;// = new[] { "Male", "Female", "Unspecified" };

        public string FileName { get; private set; }

        public byte[] Bytes { get; private set; }

        public string Result { get; private set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

        bool IsInvalid(string key)
        {
            var ms = ExceptionSingleton.ModelState;
            return ms[key].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid;
        }

         string GetErrorString()
        {
            if (ExceptionSingleton == null)
            {
                return null;
            }
            if (ExceptionSingleton.ModelState == null)
            {
                return null;
            }

            if (IsInvalid("FormFile"))
            {
                return "Select Input File";
            }

            if (IsInvalid("Extension"))
            {
                return "Select Extension";
            }

            var ex = ExceptionSingleton.Exception;
            if (ex == null)
            {
                return null;
            }
            var fff = ex.FormFile;
            if (fff == null)
            {
                return "Type of conversion output coincides with input one";
            }
            if (fff != null)
            {
                var ff = fff.FileName;
                if (ff != null)
                {
                    if (Path.GetExtension(ff).ToLower() == ".obj")
                    {
                        if (IsInvalid("AdditionalFile"))
                        {
                            return "Select Additional File";
                        }
                    }
                }
            }
            var exx = ex.Exception;
            if (exx != null)
            {
                return ex.Exception.Message;
            }
            return null;
        }

        public string ErrorString => GetErrorString();

        

        public async Task<IActionResult> OnPostUploadAsync()
        {
            try
            {
                ExceptionSingleton.ModelState = ModelState;
                /*
                if (!ModelState.IsValid)
                {
                    Result = "Please correct the form.";

                    return Page();
                }*/
                if (Directory != null | InputDirectory != null)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(1);
                    if (InputDirectory != null)
                    {
                        httpContextAccessor.HttpContext.Response.Cookies.Append("inputdir", InputDirectory, options);

                    }
                    if (Directory != null)
                    {
                        httpContextAccessor.HttpContext.Response.Cookies.Append("dir", Directory, options);
                    }
                    /*               if (FormFile != null)
                                   {
                                       httpContextAccessor.HttpContext.Response.Cookies.Append("dir", FormFile.Name, options);
                                   }
                                   if (AdditionalFile != null)
                                   {
                                       httpContextAccessor.HttpContext.Response.Cookies.Append("dir", AdditionalFile.Name, options);
                                   }*/
                }


                var ext = fileTypes[Extension.Substring(2)];

                var formFileContent =
                    await FileHelpers.ProcessFormFile<Upload3D>(
                        FormFile, ModelState, _permittedExtensions,
                        _fileSizeLimit);

                var add = await FileHelpers.ProcessFormFile<Upload3D>(
                        AdditionalFile, ModelState, _permittedExtensions,
                        _fileSizeLimit);

                Tuple<string, byte[]> tad = null;
                if (add != null)
                {
                    tad = new Tuple<string, byte[]>(AdditionalFile.FileName, add);
                }
                var inex = FormFile.FileName;
                var ex = Path.GetExtension(inex).ToLower();
                var pth = Path.GetFileNameWithoutExtension(inex);
                FileName = pth + ext.Item1[0];
                using var stream = new MemoryStream(formFileContent);
                var b = stream.ToArray();
                var path = inex;
                if (Directory != null)
                {
                    path = Path.Combine(Directory, inex);
                }
                var filename = Path.GetFileNameWithoutExtension(inex) + ext.Item1[0];
                var p = new Performer();
                object[] obj = (tad == null) ? [b] : [b, tad];
                object[] par = ext.Item2 == null ? [] : [ext.Item2];
                var byt = p.CreateAndSaveZip(path, InputDirectory, filename, Directory, null, obj, par);
                if (byt.Length == 0)
                {
                    ExceptionSingleton.Exception = new ExtendedException(null, null, null, null, null, null);
                    return RedirectToPage("./Upload3D");
                }
                var bt = new Tuple<byte[], string, string>(byt, FileName, FormFile.FileName);
                HyperLink.Tuple = bt;
                var rd = RedirectToPage("./Upload3D");
                var exc = new ExtendedException(FormFile,
                   AdditionalFile, Extension, Directory, InputDirectory, null);
                ExceptionSingleton.Exception = exc;
                return rd;
            }
            catch (Exception e)
            {
                var exc = new ExtendedException(FormFile,
                    AdditionalFile, Extension, Directory, InputDirectory, e);
                ExceptionSingleton.Exception = exc;
            }
            return Page();
        }

        public string ConvertedText => "The file \"" + Tuple.Item3 + "\" is converted";

        [BindProperty]
        [Required]
        [Display(Name = "Input File")]
        public IFormFile FormFile
        {
            get;
            set;
        }

        [BindProperty]
        [Required]
        [Display(Name = "Additional File")]
        public IFormFile ? AdditionalFile
        {
            get;
            set;
        } = null;


        [BindProperty]
        [Required]
        [Display(Name = "Directory")]
        public string ? Directory
        {
            get;
            set;
        }

        [BindProperty]
        [Required]
        [Display(Name = "Input directory")]
        public string? InputDirectory
        {
            get;
            set;
        }

        public string Download => "Download " + Tuple.Item2;
    }


    public class Upload3D
    {
        private string note = "Image";

        public Upload3D()
        {

        }

        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile1
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Additional File")]
        public IFormFile? AdditionalFile
        {
            get;
            set;
        } = null;


    }
}
