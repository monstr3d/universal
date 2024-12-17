using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using Abstract3DConverters.Meshes;


namespace Collada.Wpf
{
    partial class XamlVideo3DConverter 
    {

        Assembly assembly = typeof(Visual3D).Assembly;


        #region

        ImageSource Get(Abstract3DConverters.Image source)
        {
            System.Windows.Media.Imaging.BitmapImage bi =
                new System.Windows.Media.Imaging.BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(source.FullPath);
            bi.EndInit();
            return bi;
        }

        ModelVisual3D Get(AbstractMesh abstractMesh)
        {
            throw new NotImplementedException();
        }

        #endregion

        
    }
}
