﻿
using System.IO;
using System.Windows;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

using ErrorHandler;

namespace Collaada.Wpf.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            StaticExtensionAbstract3DConverters.CheckFile = CheckFile.Check;
            /*
            var l = new List<Material>();
            var gq = new MaterialGroup("");
            l.Add(gq);
            var rr = l.Contains(gq);
            int i = 0;
/*
            var c = new Contributor("Ivankov", "USEF", "TESTING", "@Ivankov");

            ColladaMeshConverter.Contributor = c;
*/
            //    Load();
            StaticExtensionAbstract3DConverters.UseDirectory = true;
            StaticExtensionAbstract3DConverters.Init();
            StaticExtensionAbstract3DConverters.FileTypes = new Dictionary<string, Tuple<string[], string>>()
            {
            { "AC3D file format", new Tuple<string[], string>([".ac", "ac3d"], null) },
           { "Obj file format",  new  Tuple<string[], string>([ ".obj" ], null)},
             { "Collada 1.5 file format", new Tuple<string[], string>( [ ".dae" ], "1.5.0")},
             { "Collada 1.4 file format", new Tuple<string[], string>([ ".dae" ], "1.4.1")},
               { "WPF XAML file format", new Tuple<string[], string>([ ".xaml" ], null)}
        };

            // Compare();
            //  Generate();
        //      GenerateObj();
  //                GenerateToAc();
            //    GenerateAC();
            //     GenerateCollada();
            //      GenerateToDae();
           GenerateXaml();
       //     GenerateWPF();
         //   GenerateWpf();

            //   GenerateNative();
        }

        void GenerateFormat(string format, string filename)
        {
            var p = new Performer();
            p.CreateAndSaveByUniqueName(filename, format);
        }

 

        void GenerateNative()
        {
            GenerateNative("tu154b.ac");
        }

        void GenerateNative(string s)
        {
            string dir = @"c:\AUsers\1MySoft\CSharp\03D\NATIVE\";
            var f = Path.Combine(dir, s);
            //GenerateWpf(f);

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

        string acdir = @"c:\AUsers\1MySoft\CSharp\03D\AC\\";

        void GenerateCollada()
        {
           // GenerateCollada(@"c:\AUsers\1MySoft\CSharp\03D\Collada\tu154B.dae");
            GenerateCollada(@"c:\AUsers\1MySoft\CSharp\03D\Collada\1.dae");
        }

        void GenerateXaml()
        {
            GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\GOOD\DAE\Eagle\F-15C_Eagle.dae");

            //      GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin.obj");
            //GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin.ac");
            //     GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B.dae");


            //    GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-15C Eagle.obj");
            //       GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B1.5.0.dae");
            //    GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\1(2008).dae");
            //       GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\Tornado.obj");
            //GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\Tornado1.5.0.dae");
            //                  GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin1.5.0.dae");

            //   GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin2l03rkr0.nkf1.5.0.dae");
            //   GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-16C Fighting Falcon.dae");
            //        GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-16C Fighting Falcon.obj");
            //            //  GenerateWpf(@"c:\AUsers\1MySoft\CSharp\03D\Collada\1.dae");

            // GenerateWpf(@"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.dae");
            //   GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B_poly.dae");
            //         GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154BFROMAC.dae");


            //              GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B.ac");
            //  GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin.ac");
            // GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphinNew.1.5.0.dae");

            // GenerateXaml(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-15-lowpoly.ac");

        }
        /*
                void GenerateWPF()
                {
                    GenerateWPF(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B.ac");
                    //     GenerateWpf(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin.ac");

                }
        */
        void GenerateXaml(string filename)
        {
            var fnt = Path.GetFileNameWithoutExtension(filename);
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + ".xaml");
            if (File.Exists(file))
            {
                file = Path.Combine(dir, fnt + Path.GetRandomFileName() + ".xaml");
            }
            var p = new Performer();
            try
            {
                p.CreateAndSave(filename, file);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }
/*
        void GenerateWPF(string filename)
        {
            var fnt = "WPF" + Path.GetFileNameWithoutExtension(filename);
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + ".xaml");
            if (File.Exists(file))
            {
                file = Path.Combine(dir, fnt + Path.GetRandomFileName() + ".xaml");
            }
            using var stream = File.OpenRead(filename);
            var bytes = new byte[stream.Length];
            stream.Read(bytes);
            using var outs = File.OpenWrite(file);
            var p = new Performer();
            p.CreateAndSave(filename, bytes, new WpfMeshConverter(), outs);
        }*/


        void GenerateToAc()
        {
            GenerateToAC(@"c:\AUsers\1MySoft\CSharp\03D\AC\H-60.dae");
            return;

            GenerateToAC(acdir + "1.dae");
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

        void GenerateToDae()
        {
            GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-15C Eagle.obj");
            // GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\H-60.ac");

            // GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B.ac");
            // GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-15-lowpoly.xaml");

            //      GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\tu154B.xaml");


            //    GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin.ac");

            //         GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\XAML\SU\Sukhoi PAK FA.obj");
            //  GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\1(2008).dae");
            //   GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\1.dae");
            // GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\F-15-lowpoly.ac");
            //  GenerateToDae(@"c:\AUsers\1MySoft\CSharp\03D\AC\Tornado.obj");
        }

        void GenerateToDae(string filen)
        {
            var filename = Path.Combine(acdir, filen);


            var fnt = Path.GetFileNameWithoutExtension(filename);
            var ext = Path.GetExtension(filename);
            if (ext == ".dae")
            {
                fnt += "1";
            }
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + "1.5.0.dae");
            if (File.Exists(file))
            {
                file = Path.Combine(dir, fnt + Path.GetRandomFileName() + "1.5.0.dae");

            }

            // var ac = ".dae".ToMeshConvertor("1.5.0"); // new Collada150.Collada150Converter();

            //   using var outs = File.OpenWrite(file);

            var p = new Performer();
            p.CreateAndSave(filen, file, "1.5.0");
            return;
        }

        void Generate(string ext, string filename)
        {
 /*           var fnt = Path.GetFileNameWithoutExtension(filename);
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + ext);
            if (File.Exists(file))
            {
                file = Path.Combine(dir, fnt + Path.GetRandomFileName() + ext);
            }*/
             try
            {
                var p = new Performer();
                p.CreateAndSaveByUniqueName(filename, ext);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }


        void GenerateToAC(string filename)
        {
            Generate(filename, ".ac");
            return;
            var fnt = Path.GetFileNameWithoutExtension(filename);
            var dir = Path.GetDirectoryName(filename);
            var file = Path.Combine(dir, fnt + ".ac");
            if (File.Exists(file))
            {
                file = Path.Combine(dir, fnt + Path.GetRandomFileName() + ".ac");
            }
            var p = new Performer();
            try
            {
                p.CreateAndSave(filename, file);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }



        string Generate<T>(string filename,  IMeshConverter converter,
           Action<T> action = null) where T : class
        {
            var creator = filename.ToMeshCreator();

            var p = new Performer();
            var res = p.Create<T>(creator, converter, action);
            if (converter is IStringRepresentation sr)
            {
                return  sr.ToString(res);
            }
            return null;
        }



        void GenerateCollada(string filename)
        {
           // GenerateWpf(filename);
            return;
        }

        void GenerateAC()
        {

            GenerateAC("H-60.dae");
            return;

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
            Generate(f, ".ac");
         //   GenerateWpf(f);
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
           //      GenerateObj("F15");
          //      GenerateObj("Mig29");
            GenerateObj(@"c:\AUsers\1MySoft\CSharp\03D\AC\dauphin.ac");
            //    GenerateObj("F16");
            //  GenerateObj("H6");

        }

        void GenerateObj(string obj)
        {
            Generate("Obj file format", obj);
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
