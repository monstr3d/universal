
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using Collada.Wpf;
using Wpf.Loader;

namespace Collaada.Wpf.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
             // Compare();
              Generate();
        }

        void Generate()
        {
            var d = new Dictionary<string, string>()
            {
             { "Mig29", @"c:\AUsers\1MySoft\CSharp\03D\XAML\MIG29\1857302.dae" },
             { "Tu154",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1.dae" },
             { "Tornado",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\Tornado\Tornado.dae" },
             { "Sukhoi",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.dae" },
                {"F15", @"c:\AUsers\1MySoft\CSharp\03D\XAML\F15\F-15C Eagle.dae" },

            };
            // XmlDocument doc = new XmlDocument();
            //      var f = @"c:\0\03D\UNZIP\MODELS\cadnav.com_modelMIG29\Models_G0403A048\1857302.dae";
            //  f = @"c:\0\03D\NRW\UNZIP\cadnav.com_model_TORNADO\Models_G0404A626\Tornado.dae";
            //       f = @"c:\0\03D\tu154b\Model\1.dae";
            //   f = @"c:\AUsers\1MySoft\CSharp\03D\XAML\Models_G0404A626\Tornado.dae";
            /*  f = @"c:\AUsers\1MySoft\CSharp\03D\UNZIP\MODELS\cadnav.com_modelMIG29\Models_G0403A048\1857302.dae";
              f = @"c:\AUsers\1MySoft\CSharp\03D\UNZIP\MODELS\cadnav.com_modelF16\Models_G0404A728\F-16C Fighting Falcon.dae";*/
            //      f = @"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.dae";
            //  f = @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1.dae";
            var f = "";
            //  f = d["Mig29"];
            // f = d["Tu154"];
           f = d["Tornado"];
        //    f = d["Sukhoi"];
        //    f = d["F15"];
            if (!File.Exists(f))
            {
                throw new Exception();
            }
            var fn = Path.GetFileNameWithoutExtension(f);
            var dir = Path.GetDirectoryName(f);
            var file = Path.Combine(dir, fn + ".xaml");

            //  doc.Load(f);

            DiffuseMaterial diffuse = new DiffuseMaterial();
            diffuse.Color = Color.FromArgb(255, 255, 255, 255);
            StaticExtensionColladaWpf.DefaultMaterial = diffuse;
            StaticExtensionColladaWpf.Set();
            StaticExtensionColladaWpf.Load(f);
            var r = XamlWriter.Save(StaticExtensionColladaWpf.Result);
            using (var w = new StreamWriter(file))
            {
                w.Write(r);
            }
        }


    }

}
