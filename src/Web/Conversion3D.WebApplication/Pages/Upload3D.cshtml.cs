using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using Abstract3DConverters;
using Conversion3D.WebApplication.Interfacers;
using Conversion3D.WebApplication.Pages.Shared;
using Conversion3D.WebApplication.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
           { "Collada 1.4 file format", new Tuple<string[], string>( new string[] { ".dae" }, "1.4.1")},
             { "Collada 1.5 file format", new Tuple<string[], string>( new string[] { ".dae" }, "1.5.0")},
           { "WPF XAML file format", new Tuple<string[], string>([ ".xaml" ], null)}
          };

        private readonly string _targetFilePath;

        private IBytesSingleton HyperLink { get;  set; }

        

        public Upload3DModel(IConfiguration config, IBytesSingleton hyperLink)
        {
            HyperLink = hyperLink;
            Tuple = hyperLink.Tuple;

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
            // Data.Position = 0;
            var data = new MemoryStream(Tuple.Item1);
            data.Position = 0;
            return File(data, "application/zip", Tuple.Item2 + ".zip");
        }





        public Tuple<byte[], string> ? Tuple
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


/*

        [BindProperty]
        public Upload3D FileUpload
        {
            get;
            set;
        }

*/

        public string Result { get; private set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
      public async Task<IActionResult> OnPostReferenceAsync()
        {
            

            await Task.Delay(1);

            if (Bytes == null)
            {
                return Page();
            }
            
            return File(Bytes, "application/xml", FileName);
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
                    FormFile, ModelState, _permittedExtensions,
                    _fileSizeLimit);

            var add = await FileHelpers.ProcessFormFile<Upload3D>(
                    AdditionalFile, ModelState, _permittedExtensions,
                    _fileSizeLimit);
            

            /*    var addContent =
                       await FileHelpers.ProcessFormFile<Upload3D>(
                           AddFile, ModelState, _permittedExtensions,
                           _fileSizeLimit);*/

            /*
            var ms = ModelState;
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }*/

            var inex = FormFile.FileName;

            var pp = Path.GetFileNameWithoutExtension(inex);
            FileName = pp + ext.Item1[0];



            using var stream = new MemoryStream(formFileContent);
                var b = stream.ToArray();
                var p = new Performer();
                var path = Path.Combine(Directory, inex);
                var filename = Path.GetFileNameWithoutExtension(inex) + ext.Item1[0];
                //  var r = p.CreateString(path, b, ext.Item1[0], ext.Item2);
                var byt = p.CreateAndSaveZip(path, filename, b, add, ext.Item1[0], ext.Item2, Directory);
                var bt = new Tuple<byte[], string>(byt, FileName);
  /*              var d = new Dictionary<Type, List<object>>()
                        {
                            {typeof(byte[]), new List<object>(){Bytes } }
                        };
                PageContext.Add(d, typeof(byte[]).Assembly);*/
                HyperLink.Tuple = bt;
                var rd = RedirectToPage("./HyperLink");
            return Page();

                //   using var outp = new MemoryStream();
                //            {
                //  p.CreateAndSave(path, b, ext.Item1[0], ext.Item2, Directory, outp);
                //  outp.Flush();
                //  using (var outps = new StreamWriter(outp))
                //  {
                //    outps.Write(r);

                //   return File(bt, "application/xml", fn);
    /*            var pg = Page();
                        //   return pg;

                     //   var routeValues = new { Tuple =  new Tuple<byte[], string>(Bytes, FileName) };
                        var routeValues = new { Text = "TTT" };
                        //   return RedirectToPage("./HyperLink"m);
                        var rd =  RedirectToPage("./HyperLink", routeValues);
                        var st = Zip(outp, FileName);
                        var t = new Tuple<Stream, string>(st, FileName);
                        ViewData["Tuple"] = t;
                        Request.RouteValues["Tuple"] = t;
                        
  //                  }
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

        /*    using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with a FormFile, use the following
                // instead:
                //await FileUpload.FormFile.CopyToAsync(fileStream);
            }*/

           

            //return RedirectToPage("./Index");
        }

        [BindProperty]
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile
        {
            get;
            set;
        }

        [Display(Name = "Additional File")]
        public IFormFile ? AdditionalFile
        {
            get;
            set;
        } = null;




        [BindProperty]
        [Required]
        [Display(Name = "Directory")]
        public string Directory
        {
            get;
            set;
        } = @"c:\AUsers\1MySoft\CSharp\03D\AC\";
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


        string Convert(byte[] bytes, string filaname)
        {
            /*using (var stream = new MemoryStream(bytes))
            {
                var meshCreator = filaname.ToMeshCreator(stream);
                return null;

            }*/
            return null;
        }
    }
}
