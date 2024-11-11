using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using Collada.Wpf;

namespace Collaada.Wpf.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // XmlDocument doc = new XmlDocument();
            var f = @"c:\0\03D\UNZIP\MODELS\cadnav.com_modelMIG29\Models_G0403A048\1857302.dae";
            //  f = @"c:\0\03D\NRW\UNZIP\cadnav.com_model_TORNADO\Models_G0404A626\Tornado.dae";
            f = @"c:\0\03D\tu154b\Model\1.dae";
       //     f = @"c:\0\03D\Models_G0404A626\Tornado.dae";
            var fn = Path.GetFileNameWithoutExtension(f);
            var dir = Path.GetDirectoryName(f);
            var file = Path.Combine(dir, fn + ".xaml");
            //  doc.Load(f);

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
