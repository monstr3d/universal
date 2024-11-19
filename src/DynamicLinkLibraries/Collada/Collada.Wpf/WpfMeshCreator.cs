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
            return mg;
        }

        private MeshGeometry3D Create(AbstractMesh mesh)
        {
            if (mesh.Normals.Count == 0)
            {
                return CreateWN(mesh);
            }
            var mg = new MeshGeometry3D();
            var points = new Point3DCollection();
            var textcoord = new PointCollection();
            var norm= new Vector3DCollection();
            foreach (var item in mesh.Indexes)
            {
                foreach (var idx in item)
                {
                    var kp = idx[0] - 1;
                    float[] v = vertices[kp];
                    var p = new Point3D(v[0], v[1], v[2]);
                    points.Add(p);
                    kp = idx[1] - 1;
                    v = textures[kp];
                    var t = new Point(v[0], v[1]);
                    textcoord.Add(t);
                    kp = idx[2] - 1;
                    var nn = normals[kp];
                    var normal = new Vector3D(nn[0], nn[1], nn[2]);
                    norm.Add(normal);
                }
            }
            mg.TextureCoordinates = textcoord;
            mg.Positions = points;
            mg.Normals = norm;
            return mg;

        }

     }
}
