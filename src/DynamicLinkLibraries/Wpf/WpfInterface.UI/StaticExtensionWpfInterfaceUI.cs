using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

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

        static double[] x = new double[3];
        private static Dictionary<string, Func<string, Visual3D>> dic =
               new Dictionary<string, Func<string, Visual3D>>();

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }


        internal static void Set(this System.Windows.Forms.OpenFileDialog dlg)
        {
            var dic = StaticExtensionWpfInterface.FileLoad;
            var dicp = StaticExtensionWpfLoader.FileLoad;
            foreach (string key in dic.Keys)
            {
                dlg.Filter = dlg.Filter + ";*." + key;
            }
        }

        static StaticExtensionWpfInterfaceUI()
        {

        }
    }
}
