using System.IO;
using System.Windows.Media.Media3D;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
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
            new ErrorHandler();
            string[] s = [".ac", ".dae", ".obj"];
            StaticExtensionAbstract3DConverters.Init();
            Func<string, Tuple<string, Dictionary<string, byte[]>>> f = Export;
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

        static Tuple <string, Dictionary<string, byte[]>> Export(string filename)
        {
            var c = filename.ToMeshCreator();
            return Export(filename, c);
        }

        static Tuple<string, Dictionary<string, byte[]>> Export(string filename, Abstract3DConverters.Interfaces.IMeshCreator creator)
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
            var converter = new WpfMeshConverter();
            var res = p.Create<ModelVisual3D>(creator, converter);
            res.SetLight();
             if (creator is Abstract3DConverters.Interfaces.IAdditionalInformation add)
            {
                var dic = add.Information;
                foreach (var key in dic.Keys)
                {
                    d[key] = dic[key];
                }
            }
            Abstract3DConverters.Interfaces.IStringRepresentation stringRepresentation = converter;
            var r = stringRepresentation.ToString(res);
            return new Tuple<string, Dictionary<string, byte[]>>(r, d);

        }

        class ErrorHandler : IErrorHandler
        {
            internal ErrorHandler()
            {
                this.Set();
            }


            void IErrorHandler.ShowError(Exception exception, object obj)
            {
                Diagram.UI.StaticExtensionDiagramUI.ShowError(exception, obj);
            }

            void IErrorHandler.ShowMessage(string message, object obj)
            {
                Diagram.UI.StaticExtensionDiagramUI.ShowMessage(message, obj);
            }
        }

    }
}
