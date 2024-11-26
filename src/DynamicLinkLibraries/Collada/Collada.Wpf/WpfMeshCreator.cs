using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        Service s = new();


        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;

        Performer performer = new();

        void IMeshCreator.Init(object o)
        {
            if (o is Tuple<List<float[]>, List<float[]>, List<float[]>> t)
            {
                vertices = t.Item1;
                textures = t.Item2;
                normals = t.Item3;
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
            model.Transform = Transform3D.Identity;
            foreach (var mesh in meshes)
            {
                var m = mesh as ModelVisual3D;
                model.Children.Add(m);
            }
            return model;
        }

        void IMeshCreator.SetTransformation(object mesh, float[] transformation)
        {
            var ModelVisual3D = mesh as ModelVisual3D;
            var x = s.Convert(transformation);
            var mat = new Matrix3D(x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15]);
            ModelVisual3D.Transform = new MatrixTransform3D(mat);
        }


        private MeshGeometry3D Create(AbstractMesh mesh, List<float[]> vertices, List<float[]> textures, List<float[]> normals,
            List<int[][]> indexes)
        {
            var mg = new MeshGeometry3D();
            var points = new Point3DCollection();
            var norm = new Vector3DCollection();
            var textcoord = new PointCollection();
            foreach (var item in mesh.Indexes)
            {
                foreach (var idx in item)
                {
                    var kp = idx[0];
                    if (kp >= 0)
                    {
                        float[] v = vertices[kp];
                        var p = new Point3D(v[0], v[1], v[2]);
                        points.Add(p);
                    }
                    kp = idx[1];
                    if (kp >= 0)
                    {
                        var v = textures[kp];
                        var t = new Point(v[0], v[1]);
                        textcoord.Add(t);
                    }
                    kp = idx[2];
                    if (kp >= 0)
                    {
                        var v = normals[kp];
                        var c = new Vector3D(v[0], v[1], v[2]);
                        norm.Add(c);
                    }
                }
            }
            if (textcoord.Count > 0)
            {
                mg.TextureCoordinates = textcoord;
            }
            if (points.Count > 0)
            {
                mg.Positions = points;
            }
            if (norm.Count > 0)
            {
                mg.Normals = norm;
            }
            return mg;
        }


        private MeshGeometry3D CreateWN(AbstractMesh mesh)
        {
            if (mesh.Indexes == null)
            {
                return null;
            }

            int maxv = 0;
            int maxt = 0;
            var mg = new MeshGeometry3D();
            var points = new Point3DCollection();
            var textcoord = new PointCollection();
            foreach (var item in mesh.Indexes)
            {
                foreach (var idx in item)
                {
                    var kp = idx[0];
                    maxv = Math.Max(idx[0], maxv);
                    float[] v = vertices[kp];
                    var p = new Point3D(v[0], v[1], v[2]);
                    points.Add(p);
                    kp = idx[1];
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
            if (mesh is AbstractMeshAC ac)
            {
                ac.CreatePolygons();
            }
            var ind = mesh.Indexes;
            if (ind == null)
            {
                return new MeshGeometry3D();
            }
            if (ind.Count == 0)
            {
                return new MeshGeometry3D();
            }
             var vt = vertices;
            if (vt == null)
            {
                vt = mesh.Vertices;
            }
            else if (vt.Count == 0)
            {
                vt = mesh.Vertices;
            }
            if (vt == null)
            {
                return new MeshGeometry3D();
            }
            if (vt.Count == 0)
            {
                return new MeshGeometry3D();
            }
            var nr = normals;
            if (nr == null)
            {
                nr = mesh.Normals;
            }
            else
            {
                if (nr.Count == 0)
                {
                    nr = mesh.Normals;
                }
            }
            var txt = textures;
            if (txt == null)
            {
                txt = mesh.Textures;
            }
            else if (txt.Count == 0)
            {
                txt = mesh.Textures;
            }
            return Create(mesh, vt,  txt, nr, ind);
        }

    }
}