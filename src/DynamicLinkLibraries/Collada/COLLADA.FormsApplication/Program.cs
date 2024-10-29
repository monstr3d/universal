using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using System.Xml;
using Collada;

namespace ConvertCOLLADA.FormsApplication
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
            // @"g:\Model\1.dae".ColladaToVisual3D();
           // XmlDocument doc = new XmlDocument();
            var f = @"c:\0\03D\UNZIP\MODELS\cadnav.com_modelMIG29\Models_G0403A048\1857302.dae";
            //  doc.Load(f);
            var v3d = f.ColladaToVisual3D();
            foreach (var ss in v3d.Values)
            {
                var s = XamlWriter.Save(ss);
                return;
            }

              // doc.ColladaToXaml().Save(@"c:\0\1.xaml");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
