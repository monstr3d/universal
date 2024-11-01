using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf
{
    partial  class StaticExtensionColladaOld
    {

        static Func<IdName, XmlElement, int[]>[] SearctriangleIndicesArray =
       [
             SearchTriangleIndices1
       ];

        #region Search Triangle Indices

        static XmlElement SeachTriangles(this XmlElement xmlElement)
        {
            var t = xmlElement.GetElementsByTagName("triangles");
            if (t.Count == 1)
            {
                return t[0] as XmlElement;  
            }
            return null;
        }

        static int[] SearchTriangleIndices(IdName name, XmlElement xmlElement)
        {
            foreach (var f in SearctriangleIndicesArray)
            {
                var c = f(name, xmlElement);
                if (c != null)
                {
                    return c;
                }
            }
            throw new NotImplementedException();
        }

        static int[] SearchTriangleIndicesTtiangle(IdName name, XmlElement xmlElement, XmlElement triangles)
        {
            triangles = null;

            return null;
        }

        static int[] SearchTriangleIndices1(IdName name, XmlElement xmlElement)
        {

            return null;
        }

        static void Set(this IdName name, XmlElement xmlElement, MeshGeometry3D meshGeometry)
        {
            var triangles = xmlElement.SeachTriangles();
            if (triangles != null)
            {
                Set(name, xmlElement, triangles, meshGeometry);
            }
        }

        static string[] MESHSTR = ["TEXCOORD", "VERTEX", "NORMAL"];

        static void Set(IdName name, XmlElement xmlElement, XmlElement triangles, MeshGeometry3D meshGeometry)
        {
            var s = triangles.OuterXml;
            var p = triangles.GetElementsByTagName("p")[0] as XmlElement;
            var id = p.ToIdName();
            var ints = id.Object as int[];
            var d = new Dictionary<string, float[]>();
            var ss = triangles.GetElementsByTagName("input");
            foreach (XmlElement e in ss)
            {
                var sem = e.GetAttribute("semantic");
                if (!MESHSTR.Contains(sem))
                {
                    continue;
                }
                float[] x = e.FindSource<float[]>();
                d[sem] = x;
                
            }
            var mat = triangles.GetAttribute("material");
            int mn = int.Parse(triangles.GetAttribute("count"));
            var material = mat.GetMaterial(mn);
            meshGeometry.TriangleIndices = new Int32Collection(ints);
            if (d.ContainsKey("NORMALS"))
            {
                var n = d["NORMALS"].ToVector3DList();
                meshGeometry.Normals = new Vector3DCollection(n);
            }
            if (d.ContainsKey("VERTEX"))
            {
                var pp = d["VERTEX"].ToPoint3DList();

                meshGeometry.Positions = new Point3DCollection(pp);
            }
            if (d.ContainsKey("TEXCOORD"))
            {
                var p2 = d["TEXCOORD"].ToPointList();
                meshGeometry.TextureCoordinates = new PointCollection(p2);
            }
 
        }

        


        #endregion
    }
}
