using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Windows;
using System.Xml.Linq;
using System.Linq.Expressions;

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
/*
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
*/

        MeshGeometry3D Load(XmlElement element)
        {
            var s = element.GetAllChildren<Source>();
            if (s != null)
            {
            }

            var p = element.Get<P, int[]>();
            if (p != null)
            {

            }
            var count = element.Get<VCount, int[]>();
            if (count != null)
            {
                 return new MeshGeometry3D();
            }
            return new MeshGeometry3D();
        }

        MeshGeometry3D GetMesh(XmlElement element)
        {
            XmlElement poly = element.GetChild("polylist");

            List<int[]> indi;

            if (poly != null)
            { 
                indi = poly.ToInt3Array();
            }

            var polyList = element.Get<PolyList>();
            if (polyList == null)
            {
                return Load(element);
            }
            var ind = polyList.Index;
            
            //       ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var d = polyList.Inputs;
            var indexes = polyList.Indexes;
            if (indexes.Count == 0)
            {
                throw new Exception();
            }
            Material = polyList.Material;
   
            List<Point3D> vertices = d["VERTEX"].ToPoint3DList();
            List<Vector3D> norm = d["NORMAL"].ToVector3DList();
            var textures = d["TEXCOORD"].ToPointList();
            Point3DCollection vert = new Point3DCollection();// vertices.ToPoint3DCollection();
            PointCollection textc = new PointCollection();
            Int32Collection index = new Int32Collection();
            Vector3DCollection norms = new Vector3DCollection();
            /* foreach (Point3D p in vertices)
                 {
                     vert.Add(p);
                 }*/
            Vector3D[] nt = new Vector3D[ind.Count];
            Point[] pt = new Point[ind.Count];
            /*     foreach (int[] i in ind)
              {
                  index.Add(i[0]);
                  norms.Add(norm[i[1]]);
                  textc.Add(textures[i[2]]);
              }*/
            Int32Collection tr = new Int32Collection();
            for (int i = 0; i < ind.Count; i++)
            {
                norms.Add(norm[ind[i][1]]);
                textc.Add(textures[ind[i][2]]);
                vert.Add(vertices[ind[i][0]]);
                tr.Add(i);
            }
            mesh.Positions = vert;
            mesh.Normals = norms;;
            mesh.TextureCoordinates = textc;
            mesh.TriangleIndices = tr; // new Int32Collection(polyList.Triangles);
           var trr = polyList.Triangles;
            int ii = 0;
         /*   if (tr != null)
            {
                if (tr.Length > 40)
                {

                }
                Int32Collection ints = new Int32Collection(polyList.Triangles);
                mesh.TriangleIndices = ints;
            }
            else
            {
                mesh.TriangleIndices = index;
            }

            if (mesh.TriangleIndices.Count == 0)
            {
                //throw new Exception();
            }
            mesh*.TriangleIndices = new Int32Collection();
           */
            return mesh;
            /*  GeometryModel3D geom = new GeometryModel3D();
              geom.Geometry = mesh;
              geom.Material = mat;
              mod.Content = geom;
              return mod*/
        }
    }
}