using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Collada.Wpf
{
    partial class XamlVideo3DConverter : IVisual3DConverter
    {

        private Dictionary<string, Material> materials;


        #region

        Assembly IVisual3DConverter.Assembly => assembly;

        Dictionary<string, Material> IVisual3DConverter.MaterialDictionary
        {
            get => materials;
            set => materials = value;
        }

        object IVisual3DConverter.Get(Image image)
        {
            return Get(image);
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
            return Get(mesh);
        }

        #endregion


    }
}
