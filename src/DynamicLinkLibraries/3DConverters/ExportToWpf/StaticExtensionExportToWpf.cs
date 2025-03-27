using System.IO;
using System.Linq.Expressions;
using System.Windows.Media.Media3D;
using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using AssemblyService.Attributes;

using Wpf.Loader;

namespace ExportToWpf
{
    [InitAssembly]
    public static class StaticExtensionExportToWpf
    {
        static Service s = new ();

        static StaticExtensionExportToWpf()
        {
            string[] s = [".ac", ".dae", ".obj", "*.xaml"];
            StaticExtensionAbstract3DConverters.Init();
            Func<string, Tuple<object, Dictionary<string, byte[]>>> f = Export;
            foreach (var str in s)
            {
                f.Add(str);
            }
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        static public void SetLight(this Visual3D v3d)
        {
            return;
            if (v3d is ModelVisual3D m3d)
            {
                ModelVisual3D m = new ModelVisual3D();
                AmbientLight l = new AmbientLight(System.Windows.Media.Color.FromRgb(255, 255, 255));
                m.Content = l;
                m3d.Children.Insert(0, m);
            }
        }

        static Tuple <object, Dictionary<string, byte[]>> Export(string filename)
        {

            var c = filename.ToMeshCreator(s.FileToBytes(filename));
            return Export(filename, c);
        }

        static Tuple<object, Dictionary<string, byte[]>> Export(string filename, IMeshCreator creator)
        {
            var d = new Dictionary<string, byte[]>();
            using (var stream = File.OpenRead(filename))
            {
                var b = new byte[stream.Length];
                stream.ReadExactly(b);
                var str = Path.GetFileName(filename);
                d[str] = b;
            }
            var p = new Performer();
            var converter = new Abstract3DConverters.Converters.XamlMeshConverter();
            var res = p.Create<object>(creator, converter);

            //    res.SetLight();
            if (creator is IAdditionalInformation add)
            {
                var dic = add.Information;
                if (dic != null)
                {
                    foreach (var key in dic.Keys)
                    {
                        d[key] = dic[key];
                    }
                }
            }
            if (res is XmlDocument)
            {
               //return new Tuple<object, Dictionary<string, byte[]>>(res, d);
            }
            IStringRepresentation stringRepresentation = converter;
            var r = stringRepresentation.ToString(res);
     //       using var w = new StreamWriter(@"c:\0\1.txt");
       //     w.AutoFlush = true;
      // //     w.Write(r);
        //    w.Flush();
            return new Tuple<object, Dictionary<string, byte[]>>(r, d);
        }

    }
}
