using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Windows;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Windows.Shapes;

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

        void Process(Triangles triangles, string type, Vector3DCollection norm,
        PointCollection textc)
        {
            var d = triangles.Inputs;
            var ind = triangles.Index;
            if (!d.ContainsKey(type))
            {
                return;
            }
            var val = d[type];
            var off = val.Offset;
            if (type == "VERTEX")
            {
                List<Point3D> vertices = val.Value.ToPoint3DList();

            }
        }
        MeshGeometry3D Load(XmlElement element)
        {
            var triangle = element.Get<Triangles>();
            MeshGeometry3D mesh = new MeshGeometry3D();
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var d = triangle.Inputs;
            Material = triangle.Material;
            var offv = d["VERTEX"];
            var ov = offv.Offset;
            List<Point3D> vertices = offv.Value.ToPoint3DList();
            var offt = d["TEXCOORD"];
            var ot = offt.Offset;
            var textures = offt.Value.ToPointList();
            var ind = triangle.Index;
            if (d.ContainsKey("NORMAL"))
            {
                var offn = d["NORMAL"];
                var on = offv.Offset;
                List<Vector3D> norm = offn.Value.ToVector3DList();
                Point3DCollection vert = new Point3DCollection();
                PointCollection textc = new PointCollection();
                Int32Collection index = new Int32Collection();
                var norms = new Vector3DCollection();
                for (int i = 0; i < ind.Count; i++)
                {
                    norms.Add(norm[ind[i][on]]);
                    textc.Add(textures[ind[i][ot]]);
                    vert.Add(vertices[ind[i][ov]]);
                }
                mesh.Positions = vert;
                mesh.Normals = norms;
                mesh.TextureCoordinates = textc;
                return mesh;
            }
            Point3DCollection vertt = new Point3DCollection();
            PointCollection textct = new PointCollection();
            Int32Collection indext = new Int32Collection();
            for (int i = 0; i < ind.Count; i++)
            {
                textct.Add(textures[ind[i][ot]]);
                vertt.Add(vertices[ind[i][ov]]);
            }
            mesh.Positions = vertt;
            mesh.TextureCoordinates = textct;
            return mesh;
        }

        MeshGeometry3D GetMesh(XmlElement element)
        {
            var polyList = element.Get<PolyList>();
            if (polyList == null)
            {
                return Load(element);
            }
            MeshGeometry3D mesh = new MeshGeometry3D();
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var d = polyList.Inputs;
            Material = polyList.Material;
            var offv = d["VERTEX"];
            var ov = offv.Offset;
            List<Point3D> vertices = offv.Value.ToPoint3DList();
            var offn = d["NORMAL"];
            var on = offn.Offset;
            List<Vector3D> norm = offn.Value.ToVector3DList();
            var offt = d["TEXCOORD"];
            var ot = offt.Offset;
            var textures = offt.Value.ToPointList();

            var ind = polyList.Index;
            Point3DCollection vert = new Point3DCollection();
            PointCollection textc = new PointCollection();
            Int32Collection index = new Int32Collection();
            var norms = new Vector3DCollection();
            for (int i = 0; i < ind.Count; i++)
            {
                norms.Add(norm[ind[i][on]]);
                textc.Add(textures[ind[i][ot]]);
                vert.Add(vertices[ind[i][ov]]);
            }
            mesh.Positions = vert;
            mesh.Normals = norms;
            mesh.TextureCoordinates = textc;
            return mesh;

            /*     var ind = polyList.Index;

                 //       ModelVisual3D mod = new ModelVisual3D();
                 MeshGeometry3D mesh = new MeshGeometry3D();
                 //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
                 var d = polyList.Inputs;
                 Material = polyList.Material;

                 List<Point3D> vertices = d["VERTEX"].ToPoint3DList();
                 List<Vector3D> norm = d["NORMAL"].ToVector3DList();
                 var triangles = polyList.Triangles;
                 if (3 * norm.Count != triangles.Length)
                 {
                     throw new Exception();
                 }
                 var textures = d["TEXCOORD"].ToPointList();
                 if (textures.Count != norm.Count)
                 {
                     throw new Exception();
                 }
                 Point3DCollection vert = new Point3DCollection();
                 PointCollection textc = new PointCollection();
                 Int32Collection index = new Int32Collection();
                 var norms = new Vector3DCollection();
                 for (int i = 0; i < ind.Count; i++)
                 {
                     norms.Add(norm[i]);
                     textc.Add(textures[i]);
                     if (i != ind[i][1])
                     {

                     }
                     var n = vertices.Count - ind[i][0] - 1;
                //     vert.Add(vertices[n]);
                     vert.Add(vertices[ind[i][0]]);
                 }
                 /*
                          var list = new List<int>();
              var dict = new Dictionary<int, List<Point3D>>();
              var trianlgles = polyList.Triangles;
              for (int i = 0; i < triangles.Length; i++ )
              {
                  var tri = triangles[i];
                  if (!list.Contains(tri))
                  {
                      list.Add(tri);
                  }
                  List<Point3D> l = null;
                  if (dict.ContainsKey(tri))
                  {
                      l = dict[tri];
                  }
                  else
                  {
                      l = new List<Point3D>(); 
                      dict[tri] = l;
                  }
                  l.Add(vertices[tri]);
              }

              list.Sort();
              foreach ( var v in list )
              {
                  var lt = dict[v];
                  foreach ( var t in lt )
                  {
                      vert.Add(t);
                  }
              }

              */

            //   mesh.Positions = vert;
            //  mesh.Normals = norms;
            // mesh.TextureCoordinates = textc;
            //    mesh.TriangleIndices = tr;


            //      mesh.Positions = new Point3DCollection(vertices);
            //     mesh.Normals = new Vector3DCollection(norm);
            //     mesh.TextureCoordinates = new PointCollection(textures);
            //     mesh.TriangleIndices = new Int32Collection(polyList.Triangles);
            // mesh.TriangleIndices = tr; // new Int32Collection(polyList.Triangles);
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