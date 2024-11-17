using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abstract3DConverters;

namespace Collada.Wpf
{
    partial class XamlVideo3DConverter : IVisual3DConverter
    {



        Assembly IVisual3DConverter.Assembly => typeof(System.Windows.Media.Media3D.Visual3D).Assembly;

        Path.Combine(Directory, Name) IVisual3DConverter.MaterialDictionary { get; => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        object IVisual3DConverter.Get(Image image)
        {
            throw new NotImplementedException();
        }

        object IVisual3DConverter.Get(Material material)
        {
            throw new NotImplementedException();
        }

        object IVisual3DConverter.Get(Color color)
        {
            throw new NotImplementedException();
        }

        object IVisual3DConverter.Get(AbstractMesh mesh)
        {
            throw new NotImplementedException();
        }
    }
}
