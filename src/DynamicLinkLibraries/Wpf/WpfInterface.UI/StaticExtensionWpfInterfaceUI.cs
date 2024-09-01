using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

using AssemblyService.Attributes;



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
        static public void Init()
        {

        }


        internal static void Set(this System.Windows.Forms.OpenFileDialog dlg)
        {
            var dic = StaticExtensionWpfInterface.FileLoad;
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
