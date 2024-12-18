using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

namespace Collada.Wpf
{
    public class WpfMeshConverter : IMeshConverter, IStringRepresentation
    {
        Assembly IMeshConverter.Assembly => typeof(ModelVisual3D).Assembly;

        WpfMaterialCreator creator;

        Dictionary<string, Abstract3DConverters.Materials.Material> IMeshConverter.Materials { set { } }
        Dictionary<string, Abstract3DConverters.Image> IMeshConverter.Images { set { } }

        Dictionary<string, string> imagemap = new();

        public WpfMeshConverter()
        {
            creator = new WpfMaterialCreator(imagemap);
        }

        public IMaterialCreator MaterialCreator => creator;

        Service s = new();


        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;


        void IMeshConverter.Init(object o)
        {
            if (o is Tuple<List<float[]>, List<float[]>, List<float[]>> t)
            {
                vertices = t.Item1;
                textures = t.Item2;
                normals = t.Item3;
            }
        }


        void IMeshConverter.Add(object mesh, object child)
        {
            var model = mesh as ModelVisual3D;
            var ch = child as ModelVisual3D;
            model.Children.Add(ch);
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            var model = new ModelVisual3D();
            var geom = new GeometryModel3D();
            model.Content = geom;
            geom.Geometry = Create(mesh);
            return model;
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            var model = (ModelVisual3D)mesh;
            var geom = model.Content as GeometryModel3D;
            geom.Material = material as System.Windows.Media.Media3D.Material;
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
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

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
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
                        var t = new Point(v[0], 1 - v[1]);
                        textcoord.Add(t);
                    }
                    if (idx.Length > 2)
                    {
                        kp = idx[2];
                        if (kp >= 0)
                        {
                            var v = normals[kp];
                            var c = new Vector3D(v[0], v[1], v[2]);
                            norm.Add(c);
                        }
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



        private MeshGeometry3D Create(AbstractMesh mesh, List<float[]> vertices, List<float[]> textures, List<float[]> normals)
        {
            var mg = new MeshGeometry3D();
            var points = new Point3DCollection();
            var norm = new Vector3DCollection();
            var textcoord = new PointCollection();
            foreach (var v in vertices)
            {
                var p = new Point3D(v[0], v[1], v[2]);
                points.Add(p);
            }
            foreach (var t in textures)
            {
                var p = new Point(t[0], 1 - t[1]);
                textcoord.Add(p);
            }
            if (normals != null)
            {
                foreach (var n in normals)
                {
                    var nm = new Vector3D(n[0], n[1], n[2]);
                    norm.Add(nm);
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
            if (mesh is AbstractMeshPolygon ap)
            {
                ap.Disintegrate();
                ap.CreateFromPolygons();
            }
            var ind = mesh.Indexes;
            if (ind == null)
            {
                //return new MeshGeometry3D();
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
            if (ind == null)
            {
                return Create(mesh, vt, txt, nr);
            }
            return Create(mesh, vt,  txt, nr, ind);
        }

        string IStringRepresentation.ToString(object obj)
        {
            switch (obj)
            {
                case ModelVisual3D modelVisual3D:
                    return Get(modelVisual3D);
  
            }
            return null;
        }

        string Get(ModelVisual3D modelVisual3D)
        {
            var r = System.Windows.Markup.XamlWriter.Save(modelVisual3D);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(r);
            foreach (XmlElement e in doc.GetElementsByTagName("ImageBrush"))
            {
                string iso = e.GetAttribute("ImageSource");
                foreach (var item in imagemap.Values)
                {
                    if (iso.EndsWith(item))
                    {
                        var s = item;
                        if (item[0] == '/')
                        {
                            s = s.Substring(1);
                        }
                        e.SetAttribute("ImageSource", s);
                        break;
                    }
                }
            }
            return doc.OuterXml;
 
        }
    }
}