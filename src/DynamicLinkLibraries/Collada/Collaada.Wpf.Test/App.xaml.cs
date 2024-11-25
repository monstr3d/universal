
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using Abstract3DConverters;
using Collada;
using Collada.Wpf;
using Wpf.Loader;
using Material = Abstract3DConverters.Material;

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
            // Generate();
         //  GenerateObj();
           GenerateAC();
        }

        Dictionary<string, string> models = new Dictionary<string, string>()
            {
             { "Mig29", @"c:\AUsers\1MySoft\CSharp\03D\XAML\MIG29\1857302.dae" },
             { "Tu154",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1.dae" },
             { "Tornado",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\Tornado\Tornado.dae" },
             { "Sukhoi",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.dae" },
                {"F15", @"c:\AUsers\1MySoft\CSharp\03D\XAML\F15\F-15C Eagle.dae" },
               {"F16", @"c:\AUsers\1MySoft\CSharp\03D\XAML\F-16C Fighting Falcon\F-16C Fighting Falcon.obj" },
            {"H6", @"c:\AUsers\1MySoft\CSharp\03D\XAML\Models_G0404A151\H6.obj" }


        };

        string acdir = @"c:\AUsers\1MySoft\CSharp\03D\AC";

        void GenerateAC()
        {
            GenerateAC("tu154B.ac");
        }

        Material DefaultMaterial
        {
            get
            {
                var material = new Abstract3DConverters.MaterialGroup();
                var color = new Abstract3DConverters.Color("1 1 1 1");
                var diffuse = new Abstract3DConverters.DiffuseMaterial(color);
                material.Children.Add(diffuse);
                var specular = new Abstract3DConverters.SpecularMaterial(color, 0);
                material.Children.Add(specular);
                var emissive = new Abstract3DConverters.EmissiveMaterial(color);
                material.Children.Add(emissive);
                return material;
            }
        }

        void GenerateAC(string filename)
        {
            var fn = filename;
            var converter = new AcConverter(DefaultMaterial);
            IAbstractMeshCreator meshCreator = converter;
            var f = Path.Combine(acdir, filename);
            Tuple<object, List<AbstractMesh>> l = meshCreator.Create(f);
            var list = new Dictionary<string, object>();
            var p = new Performer();
            var model = p.Combine<ModelVisual3D>(l.Item1, l.Item2, new WpfMeshCreator(), list, new WpfMaterialCreator());
            model.SetLight();
            var fnt = Path.GetFileNameWithoutExtension(fn);
            var dir = Path.GetDirectoryName(fn);
            var file = Path.Combine(dir, fnt + ".xaml");
            var r = XamlWriter.Save(model);
            using (var w = new StreamWriter(file))
            {
                w.Write(r);
            }
        }

        void GenerateObj()
        {
            GenerateObj("Tornado");
            //        GenerateObj("F15");
            //    GenerateObj("Mig29");
            //   GenerateObj("F16");
            //    GenerateObj("H6");

        }

        void GenerateObj(string obj)
        {
            var fn = models[obj].ConvertExtension(".obj");
            var converter = new Obj3DConverter();
            IAbstractMeshCreator meshCreator = converter;
            Tuple<object,    List<AbstractMesh>> l = meshCreator.Create(fn);
            IMaterialDictionary materialDictionary = converter;
            Dictionary<string, Material>  dictionary = materialDictionary.Materials;
            var mtl = new MtlWrapper();
            var list = mtl.Create(dictionary, new WpfMaterialCreator());
            var p = new Performer();
            var model  =  p.Combine<ModelVisual3D>(l.Item1, l.Item2, new WpfMeshCreator(), list, new WpfMaterialCreator());
            model.SetLight();
            var fnt = Path.GetFileNameWithoutExtension(fn);
            var dir = Path.GetDirectoryName(fn);
            var file = Path.Combine(dir, fnt + ".xaml");
            var r = XamlWriter.Save(model);
            using (var w = new StreamWriter(file))
            {
                w.Write(r);
            }
        }




        void Generate()
        {
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
           f = models["Tornado"];
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

            System.Windows.Media.Media3D.DiffuseMaterial diffuse = new System.Windows.Media.Media3D.DiffuseMaterial();
            diffuse.Color = System.Windows.Media.Color.FromArgb(255, 255, 255, 255);
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
