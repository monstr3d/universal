using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Windows;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;

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

        MeshGeometry3D LoadSimple(XmlElement element)
        {

            MeshGeometry3D mesh = new MeshGeometry3D();
            return mesh;
            var de = element.GetAllChildren<Input>().ToArray();
            var d = new Dictionary<string, OffSet>();
            foreach (var inp in de)
            {
                var sem = inp.Semantic;
                d[sem.Key] = sem.Value;
            }
            var p = element.Get<P>();
            if (p != null)
            {
                throw new Exception();
            }
            Material = this.Material;
            if (Material == null)
            {
                Material = StaticExtensionColladaWpf.DefaultMaterial;
            }
            var offv = d["VERTEX"];
            var ov = offv.Offset;
            List<Point3D> vertices = offv.Value.ToPoint3DList();
            var n = vertices.Count;
            var offn = d["NORMAL"];
            var on = offn.Offset;
            List<Vector3D> norm = offn.Value.ToVector3DList();
            var offt = d["TEXCOORD"];
            var ot = offt.Offset;
            var textures = offt.Value.ToPointList(true);
            var vert = new Point3DCollection();
            var textc = new PointCollection();
            var  norms = new Vector3DCollection();
            Int32Collection index = new Int32Collection();
            for (int i = 0; i < vertices.Count; i++)
            {
                vert.Add(vertices[i]);
            }
            for (int i = 0; i < norm.Count; i++)
            {
                norms.Add(norm[i]);
            }
            for (int i = 0; i < textures.Count; i++)
            {
                textc.Add(textures[i]);
            }

            mesh.Positions = vert;
            mesh.Normals = norms;
            mesh.TextureCoordinates = textc;

            return mesh;
        }





        MeshGeometry3D Load(XmlElement element)
        {
            var triangle = element.Get<Triangles>();
            if (triangle == null)
            {
                return LoadSimple(element);
            }
            MeshGeometry3D mesh = new MeshGeometry3D();
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var d = triangle.Inputs;
            Material = triangle.Material;
            var offv = d["VERTEX"];
            var ov = offv.Offset;
            List<Point3D> vertices = offv.Value.ToPoint3DList();
            Point3DCollection vert = new Point3DCollection();
            PointCollection textc = new PointCollection();
            Int32Collection index = new Int32Collection();
            Vector3DCollection norms = new Vector3DCollection();
            var ind = triangle.Indexes;
            for (int i = 0; i < ind.Count; i++)
            {
                vert.Add(vertices[ind[i][ov]]);
            }
            Process(triangle, "NORMAL", norms, textc);
            Process(triangle, "TEXCOORD", norms, textc);
            mesh.Positions = vert;
            mesh.TextureCoordinates = textc;
            mesh.Normals = norms;
            return mesh;
        }
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
            var v = val.Value;
            if (type == "TEXCOORD")
            {
                var textur = v.ToPointList(true);
                foreach (var i in ind)
                {
                    textc.Add(textur[i[off]]);
                }
                return;
            }
            var normals = v.ToVector3DList();
            foreach (var i in ind)
            {
                norm.Add(normals[i[off]]);
            }

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
            var textures = offt.Value.ToPointList(true);
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
            if (vert.Count != textures.Count)
            {

            }
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