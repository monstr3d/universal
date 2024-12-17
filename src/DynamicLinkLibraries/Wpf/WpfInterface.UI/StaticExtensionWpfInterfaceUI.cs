using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

using AssemblyService.Attributes;
using DataSetService;
using Wpf.Loader;



namespace WpfInterface.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionWpfInterfaceUI
    {

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
           // var dic = StaticExtensionWpfInterface.FileLoad;
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

        }
    }
}
