using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Collaada.Wpf.Test
{
    public class Comparer : IEqualityComparer<MeshGeometry3D>
    {

        public static IEqualityComparer<MeshGeometry3D> Inatance = new Comparer();

        bool IEqualityComparer<MeshGeometry3D>.Equals(MeshGeometry3D? x, MeshGeometry3D? y)
        {
            /*  var xx = x.Positions;
              var yy = y.Positions;
              for (var i = 0; i < xx.Count; i++)
              {
                  var a = xx[i];
                  var b = yy[i];
                  if (!a.Equals(b))
                      return false;
              }
              return true;*/
            var xx = x.TextureCoordinates;
            var yy = y.TextureCoordinates;
            if (xx.Count == 0 | yy.Count == 0)
            {
                return false;
            }
            if (!xx[0].Equals(yy[0]))
            {
                return false;
            }
            if (xx.Count != yy.Count)
            {
                return false;
            }
            if (xx.Count > 10)
            {

            }
            for (int i = 0; i < xx.Count; i++)
            {
                if (!xx[i].Equals(yy[i]))
                {

                }
            }
            if (x.TextureCoordinates != y.TextureCoordinates)
            {

            }
            return xx.Count == yy.Count;
        }

        int IEqualityComparer<MeshGeometry3D>.GetHashCode(MeshGeometry3D obj)
        {
            return obj.Positions.Count;
        }

        public static IEnumerable<MeshGeometry3D> Get(ModelVisual3D model)
        {
             if (model.Content is GeometryModel3D g)
            {
               if (g.Geometry is MeshGeometry3D mesh)
                {
                    yield return mesh;
                }

            }
            foreach (var obj in model.Children)
            {
                if (obj is ModelVisual3D modelVisual3D)
                {
                    IEnumerable<MeshGeometry3D> meshGeometry3s = Get(modelVisual3D);
                    foreach (var meshGeometry3d in meshGeometry3s) { yield return meshGeometry3d; }
                }
            }
        }
    }
}
