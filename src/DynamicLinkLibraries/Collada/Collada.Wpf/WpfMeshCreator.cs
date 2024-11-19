using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Abstract3DConverters;

namespace Collada.Wpf
{
    public class WpfMeshCreator : IMeshCreator
    {
        Assembly IMeshCreator.Assembly => typeof(ModelVisual3D).Assembly;

        int currentVerex = 1;

        int currentTexture = 1;

        List<float[]> vertices = new List<float[]>();

        List<float[]> textures = new List<float[]>();
        
        List<float[]> normals = new List<float[]>();

        void IMeshCreator.Init(IEnumerable<AbstractMesh> meshes)
        {
             foreach (var mesh in meshes)
            {
                vertices.AddRange(mesh.Vertices);
                textures.AddRange(mesh.Textures);
                normals.AddRange(mesh.Normals);
            }
        }


        void IMeshCreator.Add(object mesh, object child)
        {
            var model = mesh as ModelVisual3D;
            var ch = child as ModelVisual3D;
            model.Children.Add(ch);
        }

        object IMeshCreator.Create(AbstractMesh mesh)
        {
           var model = new ModelVisual3D();
            var geom = new GeometryModel3D();
            model.Content = geom;
            geom.Geometry = Create(mesh);
            return model;
        }

        void IMeshCreator.SetMaterial(object mesh, object material)
        {
            var model = (ModelVisual3D)mesh;
            var geom = model.Content as GeometryModel3D;
            geom.Material = material as System.Windows.Media.Media3D.Material;
        }

        object IMeshCreator.Combine(IEnumerable<object> meshes)
        {
            var model = new ModelVisual3D();
            foreach (var mesh in meshes)
            {
                var m = mesh as ModelVisual3D;
                model.Children.Add(m);
            }
            return model;
        }


        private MeshGeometry3D CreateWN(AbstractMesh mesh)
        {
            int maxv = 0;
            int maxt = 0;
            var mg = new MeshGeometry3D();
            var points = new Point3DCollection();
            var textcoord = new PointCollection();
             foreach (var item in mesh.Indexes)
            {
                foreach (var idx in item)
                {
                    var kp = idx[0] - 1;
                    maxv = Math.Max(idx[0], maxv);
                    float[] v = vertices[kp];
                    var p = new Point3D(v[0], v[1], v[2]);
                    points.Add(p);
                    kp = idx[1] - 1;
                    maxt = Math.Max(idx[1], maxt);
                    v = textures[kp];
                    var t = new Point(v[0], v[1]);
                    textcoord.Add(t);
                }
            }
            mg.TextureCoordinates = textcoord;
            mg.Positions = points;
            currentVerex = maxv + 1;
            currentTexture = maxt + 1;
            return mg;

        }

        private MeshGeometry3D Create(AbstractMesh mesh)
        {
            if (mesh.Normals.Count == 0)
            {
                return CreateWN(mesh);
            }
            var meshGeometry = new MeshGeometry3D();
            var points = new Point3DCollection();
            foreach (var point in mesh.Vertices)
            {
                points.Add(new Point3D(point[0], point[1], point[2]));
            }
            var norms = new Vector3DCollection();
            foreach (var item in mesh.Normals)
            {
                norms.Add(new Vector3D(item[0], item[1], item[2]));
            }
            var textcoord = new PointCollection();
            foreach (var n in mesh.Textures)
            {
                textcoord.Add(new Point(n[0], n[1]));
            }
            var ind = new Int32Collection();
            foreach (var item in mesh.Indexes)
            {
                foreach (var idx in item)
                {
                    foreach (var i in idx)
                    {
                        ind.Add(i);
                    }
                }
            }
            meshGeometry.Positions = points;
            meshGeometry.Normals = norms;
            meshGeometry.TextureCoordinates = textcoord;
            meshGeometry.TriangleIndices = ind;
            return meshGeometry;

        }

     }
}
