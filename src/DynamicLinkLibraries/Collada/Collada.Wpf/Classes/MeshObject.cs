using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Windows;

namespace Collada.Wpf.Classes
{
    [Tag("mesh")]
    internal class MeshObject : Collada.XmlHolder
    {
        static public readonly string Tag = "mesh";

        public Visual3D Visual3D { get; private set; }

        private MeshObject(XmlElement element) : base(element)
        {
            Visual3D = GetMesh(element);
        }

        object Get()
        {
            return Visual3D;
        }

        public static object Get(XmlElement element)
        {
            var a = new MeshObject(element);
            return a.Get();
        }

        static Visual3D GetMesh(XmlElement element)
        {
            ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material mat = null;
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            PolyList polyList = element.Get<PolyList>();
            var d = polyList.Inputs;
            var indexes = polyList.Indexes;

            List<Point3D> vertices = (d["VERTEX"] as double[]).ToPoint3DList();
            List<Vector3D> norm = (d["NORMAL"] as double[]).ToVector3DList();
            List<Point> textures = (d["TEXCOORD"] as double[]).ToPointList();
            Point3DCollection vert = new Point3DCollection();
            PointCollection textc = new PointCollection();
            Int32Collection index = new Int32Collection();
            Vector3DCollection norms = new Vector3DCollection();
            /* foreach (Point3D p in vertices)
             {
                 vert.Add(p);
             }*/
            Vector3D[] nt = new Vector3D[indexes.Count];
            Point[] pt = new Point[indexes.Count];
            /*
            foreach (int[] i in indexes)
            {
                index.Add(i[0]);
                norms.Add(norm[i[1]]);
                textc.Add(textures[i[2]]);
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                norms.Add(norm[i]);
                textc.Add(textures[i]);
                vert.Add(vertices[indexes[i][0]]);
            }
            mesh.Positions = vert;
            mesh.Normals = norms;
            mesh.TextureCoordinates = textc;
            mesh.TriangleIndices = index;
            GeometryModel3D geom = new GeometryModel3D();
            geom.Geometry = mesh;
            geom.Material = mat;
            mod.Content = geom;
            return mod;*/
            return mod;
        }
    }
}