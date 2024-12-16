using System.IO;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using Abstract3DConverters;
using AssemblyService.Attributes;
using Collada.Wpf;
using Wpf.Loader;

namespace ExportToWpf
{
    [InitAssembly]
    public static class StaticExtensionExportToWpf
    {

        static StaticExtensionExportToWpf()
        { 
            StaticExtensionAbstract3DConverters.Init();
            Func<string, Tuple<string, Dictionary<string, byte[]>>> f = ExportAC;
            f.Add(".ac");
            f = ExportCollada;
            f.Add(".dae");
            f = ExportObj;
            f.Add(".obj");
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        static public void SetLight(this Visual3D v3d)
        {
            if (v3d is ModelVisual3D m3d)
            {
                ModelVisual3D m = new ModelVisual3D();
                AmbientLight l = new AmbientLight(System.Windows.Media.Color.FromRgb(255, 255, 255));
                m.Content = l;
                m3d.Children.Insert(0, m);
            }
        }

        static Tuple<string, Dictionary<string, byte[]>> ExportAC(string filename)
        {
            return Export(filename, new AcCreator());
        }

        static Tuple<string, Dictionary<string, byte[]>> ExportObj(string filename)
        {
            return Export(filename, new Obj3DConverter());
        }


        static Tuple<string, Dictionary<string, byte[]>> ExportCollada(string filename)
        {
            return Export(filename, new Collada.Converter.Collada14MeshCreator());
        }


        static Tuple<string, Dictionary<string, byte[]>> Export(string filename, IMeshCreator creator)
        {
            var d = new Dictionary<string, byte[]>();
            using (var stream = File.OpenRead(filename))
            {
                var b = new byte[stream.Length];
                stream.Read(b);
                var str = Path.GetFileName(filename);
                d[str] = b;
            }
            var p = new Performer();
            var res = p.Create<ModelVisual3D>(filename, creator, new WpfMeshConverter());
            res.SetLight();
            var r = XamlWriter.Save(res);
            if (creator is IAdditionalInformation add)
            {
                var dic = add.Information;
                foreach (var key in dic.Keys)
                {
                    d[key] = dic[key];
                }
            }
            return new Tuple<string, Dictionary<string, byte[]>>(r, d);

        }

    }
}
