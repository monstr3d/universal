using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Abstract3DConverters;

namespace Collada.Wpf
{
    public class XamlConverter
    {

        public IEnumerable<ModelVisual3D> Convert(IEnumerable<AbstractMesh> input, Dictionary<string, Material> keyValues)
        {
            
            foreach (var mesh in input)
            {
                var model = new ModelVisual3D();
                var g = new GeometryModel3D();
                var mat = mesh.Material;
                if (keyValues.ContainsKey(mat))
                {
                    g.Material = keyValues[mat];
                }
                var mg= new MeshGeometry3D();
                model.Content = g;
                g.Geometry = mg;
                var vertices = new Point3DCollection();
                var norm = new Vector3DCollection();
                var txt = new StringBuilder();
            }
        }
    }
}
