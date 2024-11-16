using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Wpf.Loader;

namespace Collaada.Wpf.Test
{
    internal  static class StaticExtenrion
    {
 
       static  void Compare()
        {
            var wr1 = new XamlWrapper();
            wr1.Load(@"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1.xaml");

            var wr2 = new XamlWrapper();

            wr2.Load(@"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\2.xaml");

            var v1 = wr1.Visual;

            var ww1 = Comparer.Get(v1 as ModelVisual3D).ToList();

            var ww2 = Comparer.Get(wr2.Visual as ModelVisual3D).ToList();

            var c = Comparer.Inatance;

            foreach (var x1 in ww1)
            {
                foreach (var x2 in ww2)
                {
                    if (c.GetHashCode(x1) == c.GetHashCode(x2))
                    {
                        c.Equals(x1, x2);
                    }
                }
            }

        }


    }
}
