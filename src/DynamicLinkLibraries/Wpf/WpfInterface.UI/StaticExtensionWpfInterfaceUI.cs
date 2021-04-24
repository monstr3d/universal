using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;
using System.Windows.Media.Media3D;

using WpfInterface;


namespace WpfInterface.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionWpfInterfaceUI
    {

        static double[] x = new double[3];
        private static Dictionary<string, Func<string, System.Windows.Media.Media3D.Visual3D>> dic =
               new Dictionary<string, Func<string, System.Windows.Media.Media3D.Visual3D>>();

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
        }


        internal static void Set(this System.Windows.Forms.OpenFileDialog dlg)
        {
            Dictionary<string, Func<string, System.Windows.Media.Media3D.Visual3D>> dic =
            StaticExtensionWpfInterface.FileLoad;
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
