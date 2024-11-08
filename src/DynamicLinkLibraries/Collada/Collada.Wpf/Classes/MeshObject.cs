using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Windows;
using System.Xml.Linq;

namespace Collada.Wpf.Classes
{
    [Tag("mesh")]
    internal class MeshObject : Collada.XmlHolder
    {
        static public readonly string Tag = "mesh";

        public MeshGeometry3D MeshGeometry3D { get; private set; }

        public Material Material { get; private set; }

        private MeshObject(XmlElement element) : base(element)
        {
            MeshGeometry3D = GetMesh(element);
        }

        object Get()
        {
            return MeshGeometry3D;
        }

        public static object Get(XmlElement element)
        {
            var a = new MeshObject(element);
            return a; ;
        }

        static MeshGeometry3D GetMeshSimple(XmlElement element)
        {
            try
            {
                var mesh = new MeshGeometry3D();
                var verices = element.Get<Vertices>();
                var v = verices.ToPoint3DList().ToPoint3DCollection();
                mesh.Positions = v;
                return mesh;
            }
            catch (Exception e)
            {


            }
            throw new Exception();
        }

        MeshGeometry3D GetMesh(XmlElement element)
        {
            var polyList = element.Get<PolyList>();
            if (polyList == null)
            {
                return GetMeshSimple(element);
            }
            //       ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var d = polyList.Inputs;
            var indexes = polyList.Indexes;
            Material = polyList.Material;

            List<Point3D> vertices = d["VERTEX"].ToPoint3DList();
            List<Vector3D> norm = d["NORMAL"].ToVector3DList();
            List<Point> textures = d["TEXCOORD"].ToPointList();
            Point3DCollection vert = vertices.ToPoint3DCollection();
            PointCollection textc = new PointCollection();
            Int32Collection index = new Int32Collection();
            Vector3DCollection norms = new Vector3DCollection();
            Vector3D[] nt = new Vector3D[indexes.Count];
            Point[] pt = new Point[indexes.Count];

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
           
            return mesh;
            /*  GeometryModel3D geom = new GeometryModel3D();
              geom.Geometry = mesh;
              geom.Material = mat;
              mod.Content = geom;
              return mod*/
        }
    }
}