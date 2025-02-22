using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Media3D;
using Abstract3DConverters;
using AssemblyService.Attributes;
using Wpf.Loader;



namespace WpfInterface.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionWpfInterfaceUI
    {
        public const string deleteTexture = "delete_texture_file_";


        static double[] x = new double[3];
        private static Dictionary<string, Func<string, Visual3D>> dic =
               new Dictionary<string, Func<string, Visual3D>>();

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }


        internal static void Set(this System.Windows.Forms.OpenFileDialog dlg)
        {
  
            var dicp = StaticExtensionWpfLoader.FileLoad;
            var s1 = "3D files |";
            var s2 = "";
            foreach (string key in dicp.Keys)
            {
                  s1 += "*" + key + ";";
    //            s1 += ss + ";";
    //            s2 += "|*" + key + ";";
            }
            // s1 = s1.Substring(0, s1.Length - 1) + ")";
            var f = s1.Substring(0, s1.Length - 1);
            dlg.Filter = f;
        }

        static StaticExtensionWpfInterfaceUI()
        {
            new FilenameGenerator();
            StaticExtensionAbstract3DConverters.FileTypes = new Dictionary<string, Tuple<string[], string>>()
            {
            { "AC3D file format", new Tuple<string[], string>([".ac", "ac3d"], null) },
           { "Obj file format",  new  Tuple<string[], string>([ ".obj" ], null)},
             { "Collada 1.5 file format", new Tuple<string[], string>( [ ".dae" ], "1.5.0")},
             { "Collada 1.4 file format", new Tuple<string[], string>([ ".dae" ], "1.4.1")},
               { "WPF XAML file format", new Tuple<string[], string>([ ".xaml" ], null)}
        };


        }

        class FilenameGenerator : IFilenameGenerator
        {
            internal FilenameGenerator()
            {
                this.Set();
            }

            void IFilenameGenerator.Clean()
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
                {
                    dir += Path.DirectorySeparatorChar;
                }
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    if (file.Contains("delete_texture_file"))
                    {
                        try
                        {
                            System.IO.File.Delete(file);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            string IFilenameGenerator.GenerateFileName(string ext, out string path)
            {
                string ss = Path.GetRandomFileName() + "";
                ss = ss.Replace('-', '_');
                ss = deleteTexture + ss + ext;
                string fn = AppDomain.CurrentDomain.BaseDirectory;
                if (fn[fn.Length - 1] != Path.DirectorySeparatorChar)
                {
                    fn += Path.DirectorySeparatorChar;
                }
                path = fn + ss;
                return ss;
            }
        }
    }
}
