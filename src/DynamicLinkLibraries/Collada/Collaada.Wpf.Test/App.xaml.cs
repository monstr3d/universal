
using System;
using System.IO;
using System.Net.WebSockets;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Converters;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Collada;
using Collada.Converter;
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
            StaticExtensionAbstract3DConverters.Init();
            // Compare();
            //  Generate();
            //     GenerateObj();
            //  GenerateToAc();
            // GenerateAC();
            //     GenerateCollada();
            GenerateWpf();
        }

        Dictionary<string, string> models = new Dictionary<string, string>()
            {
             { "Mig29", @"c:\AUsers\1MySoft\CSharp\03D\XAML\MIG29\1857302.dae" },
             { "Tu154",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\tu154B.dae" },
             { "1",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1.dae" },
             { "11",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\11.xml" },
             { "1NEW",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1NEW.dae" },
             { "Tornado",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\Tornado\Tornado.dae" },
             { "Sukhoi",  @"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.dae" },
                {"F15", @"c:\AUsers\1MySoft\CSharp\03D\XAML\F15\F-15C Eagle.dae" },
               {"F16", @"c:\AUsers\1MySoft\CSharp\03D\XAML\F-16C Fighting Falcon\F-16C Fighting Falcon.obj" },
            {"H6", @"c:\AUsers\1MySoft\CSharp\03D\XAML\Models_G0404A151\H6.obj" }


        };

        string acdir = @"c:\AUsers\1MySoft\CSharp\03D\AC";

        void GenerateCollada()
        {
           // GenerateCollada(@"c:\AUsers\1MySoft\CSharp\03D\Collada\tu154B.dae");
            GenerateCollada(@"c:\AUsers\1MySoft\CSharp\03D\Collada\1.dae");
        }

        void GenerateWpf()
        {
         //  GenerateWpf(@"c:\AUsers\1MySoft\CSharp\03D\Collada\1.dae");

          GenerateWpf(@"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.dae");
        }

        void GenerateWpf(string filename)
        {
            var converter = new WpfMeshConverter();
            var fnt = Path.GetFileNameWithoutExtension(filename);
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + ".xaml");
            var act = (ModelVisual3D m) =>
            {
                m.SetLight();

            };
            
       
            var obj = Generate<ModelVisual3D>(filename, converter,  act);
            IStringRepresentation r = converter;
            var s = r.ToString(obj);
            using (var writer = new StreamWriter(file))
            {

                writer.Write(s);
            }
        }

        void GenerateToAc()
        {
            GenerateToAC("1.dae");
            return;
            GenerateToAC("dauphin.ac");
            return;
            GenerateAC("tu154B.ac");
            return;
            GenerateAC("H-60.ac");
            return;
            //  GenerateAC("F-15-lowpoly.ac");
            GenerateAC("testpilot.ac");

        }

        void GenerateToAC(string filen)
        {
            var filename = Path.Combine(acdir, filen);

            var creator = filename.ToMeshCreator();

            var fnt = Path.GetFileNameWithoutExtension(filename);
            var ext = Path.GetExtension(filename);
            if (ext == ".ac")
            {
                fnt += "1";
            }
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + ".ac");
            var ac = new AcConverter();

            var obj = Generate<object>(filename, ac);
            using (var writer = new StreamWriter(file))
            {
                writer.Write(obj);
            }
        }



        string Generate<T>(string filename,  IMeshConverter converter,
           Action<T> action = null) where T : class
        {
            var creator = filename.ToMeshCreator();

            var p = new Performer();
            var res = p.Create<T>(filename, creator, converter, action);
            if (converter is IStringRepresentation sr)
            {
                return  sr.ToString(res);
            }
            return null;
        }



        void GenerateCollada(string filename)
        {
            GenerateWpf(filename);
            return;
        }

        void GenerateAC()
        {

            GenerateAC("dauphin.ac");
            return;
            GenerateAC("tu154B.ac");
              return;
             GenerateAC("H-60.ac");
            return;
           //  GenerateAC("F-15-lowpoly.ac");
             GenerateAC("testpilot.ac");
        }

        Abstract3DConverters.Materials.Material DefaultMaterial
        {
            get
            {
                /*            var material = new MaterialGroup();
                            var color = new Abstract3DConverters.Color("1 1 1 1");
                            var diffuse = new Abstract3DConverters.DiffuseMaterial(color, null, null);
                            material.Children.Add(diffuse);
                            var specular = new Abstract3DConverters.SpecularMaterial(color, 0);
                            material.Children.Add(specular);
                            var emissive = new Abstract3DConverters.EmissiveMaterial(color);
                            material.Children.Add(emissive);
                            return material;*/
                return null;

            }
        }

        

        void GenerateAC(string filename)
        {
            var f = Path.Combine(acdir, filename);
            GenerateWpf(f);
            return;
            /*        var fn = filename;
                    var converter = new AcConverter();
                    AbstractMeshCreator meshCreator = converter;
                    var f = Path.Combine(acdir, filename);
                    Tuple<object, List<AbstractMesh>> l = meshCreator.Create(f);
                    var list = new Dictionary<string, object>();
                    var p = new Performer();
                    var model = p.Combine<ModelVisual3D>(l.Item1, l.Item2, new WpfMeshConverter(), list, new WpfMaterialCreator());
                    model.SetLight();
                    var fnt = Path.GetFileNameWithoutExtension(fn);
                    var dir = Path.GetDirectoryName(fn);
                    var file = Path.Combine(acdir, fnt + ".xaml");
                    var r = XamlWriter.Save(model);
                    using (var w = new StreamWriter(file))
                    {
                        w.Write(r);
                    }*/
        }

        void GenerateObj()
        {
          //  GenerateObj("Tornado");
                 GenerateObj("F15");
          //      GenerateObj("Mig29");
           // GenerateObj("Sukhoi");
            //    GenerateObj("F16");
            //  GenerateObj("H6");

        }

        void GenerateObj(string obj)
        {
            var fn = models[obj].ConvertExtension(".obj");
            GenerateWpf(fn);
            return;

            /*      var converter = new Obj3DConverter();
                 AbstractMeshCreator meshCreator = converter;
                 Tuple<object,  List<AbstractMesh>> l = meshCreator.Create(fn);
                 IMaterialDictionary materialDictionary = converter;
                 Dictionary<string, Abstract3DConverters. Material>  dictionary = materialDictionary.Materials;
                 var mtl = new MtlWrapper();
                 var list = mtl.Create(dictionary, new WpfMaterialCreator());
                 var p = new Performer();
                 var model  =  p.Combine<ModelVisual3D>(l.Item1, l.Item2, new WpfMeshConverter(), list, new WpfMaterialCreator());
                 model.SetLight();
                 var fnt = Path.GetFileNameWithoutExtension(fn);
                 var dir = Path.GetDirectoryName(fn);
                 var file = Path.Combine(dir, fnt + ".xaml");
                 var r = XamlWriter.Save(model);
                 using (var w = new StreamWriter(file))
                 {
                     w.Write(r);
                 }*/
        }




        void Generate()
        {
        }


    }

}
