using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

using WpfInterface;

namespace Collada.FileLoader
{
    /// <summary>
    /// File loader of collada
    /// </summary>
    public static class StaticExtensionColladaFileLoader
    {
        
        /// <summary>
        /// Sets collada file loader
        /// </summary>
        public static void Set()
        {
            Dictionary<string, Func<string, Visual3D>> d =
                WpfInterface.StaticExtensionWpfInterface.FileLoad;
            d["dae"] = GetVisual3D;
        }

        static Visual3D GetVisual3D(string filename)
        {
            FormScale f = new FormScale();
            f.ShowDialog();
            double sc = f.Scale;
            Dictionary<string, Visual3D> d = filename.ColladaToVisual3D();
            foreach (string key in d.Keys)
            {
                Visual3D v = d[key];
                if (sc != 1)
                {
                    v.Multiply(sc);
                }
                return v;
            }
            return null;
        }
    }
}
