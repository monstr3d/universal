using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf
{
    partial class ColladaObject
    {


        Dictionary<string, Func<XmlElement, object>> functions;

        Dictionary<string, Func<XmlElement, Visual3D>> visualDic;

        Dictionary<string, Func<XmlElement, object>> sourceDic;

        object GetVetrices<T>(XmlElement element) where T : struct
        {
            T[] x = element.FindSourceChild<T[]>();
            return x;
        }
        object GetScenes(XmlElement element)
        {
            return new Scene(element);
        }
        static object GetP(XmlElement element)
        {
            return element.ToRealArray<int>();
        }

        object GetFloatArray(XmlElement element)
        {
            return element.ToRealArray<float>();
        }

        object GetGeometry(XmlElement element)
        {
            XmlElement e = element.FirstChild as XmlElement;
            string type = e.Name;
            if (visualDic.ContainsKey(type))
            {
                Visual3D v3d = visualDic[type](e);
                return v3d;
            }
            return null;
        }


        Visual3D GetMesh(XmlElement element)
        {
            ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material mat = null;
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var poly = element.GetChild("polylist");
            if (poly != null)
            {

                List<int[]> ind = poly.ToInt3Array();
                mat = poly.GetAttribute("material").Find<Material>();
                 if (mat == null)
                {
                    return null;
                }
                XmlNodeList nl = poly.GetElementsByTagName("input");
                Dictionary<string, object> d = poly.FindInputs();
                List<Point3D> vertices = (d["VERTEX"] as double[]).ToPoint3DList();
                List<Vector3D> norm = (d["NORMAL"] as double[]).ToVector3DList();
                List<System.Windows.Point> textures = (d["TEXCOORD"] as double[]).ToPointList();
                Point3DCollection vert = new Point3DCollection();
                PointCollection textc = new PointCollection();
                Int32Collection index = new Int32Collection();
                Vector3DCollection norms = new Vector3DCollection();
                Vector3D[] nt = new Vector3D[ind.Count];
                var pt = new System.Windows.Point[ind.Count];
                for (int i = 0; i < ind.Count; i++)
                {
                    norms.Add(norm[i]);
                    textc.Add(textures[i]);
                    vert.Add(vertices[ind[i][0]]);
                }
                mesh.Positions = vert;
                mesh.Normals = norms;
                mesh.TextureCoordinates = textc;
                mesh.TriangleIndices = index;
                GeometryModel3D geom = new GeometryModel3D();
                geom.Geometry = mesh;
                geom.Material = mat;
                mod.Content = geom;
            }
            else
            {
                GeometryModel3D geom = new GeometryModel3D();
                geom.Geometry = mesh;
                mod.Content = geom;
            }
            var ss = element.GetElementsByTagName("source");
            foreach (XmlElement s in ss)
            {
                if (s.ParentNode != element)
                {
                    continue;
                }
    
            }
            ss = element.GetElementsByTagName("triangles");
            if (ss.Count == 1)
            {
                var tringles = ss[0] as XmlElement;

            }
            return mod;
        }


        private  object GetEffect(XmlElement element)
        {
            var effect = new BlurEffect();
            return effect;
        }

        private object CalculateMaterialObject(XmlElement e)
        {
            var l = CalculateMaterial(e);
            return l.SimplifyMaterial();
        }


        private List<Material> CalculateMaterial(XmlElement element)
        {
            var materials = new List<Material>();
            foreach (string key in materialCalc.Keys)
            {
                XmlNodeList nlp = element.GetElementsByTagName(key);
                foreach (XmlElement xmlElement in nlp)
                {
                    var o = xmlElement.Get();
                    if (o is Material mm)
                    {
                        materials.Add(mm);
                        continue;
                    }
                    var mat = materialCalc[key](xmlElement);
                    if (mat != null)
                    {
                        
                        if (o != null)
                        {
                            if (o != mat)
                            {
                                throw new Exception();
                            }
                        }
                        o = xmlElement.Get();
                        if (o != null)
                        {
                            if (o != mat)
                            {
                                throw new Exception();
                            }
                            xmlElement.Set(mat);
                        }
                        if (mat is MaterialGroup mg)
                        {
                            foreach (Material mmt in mg.Children)
                            {
                                materials.Add(mmt);
                                continue; 
                            }
                        }
                        else
                        {
                            materials.Add(mat);
                        }

                    }
                }
            }
            return materials;
        }

        Material GetInstanceEffectMaterial(XmlElement xmlElement)
        {
            var materials = new List<Material>();
            var url = xmlElement.GetAttribute("url");
            var tag = url.Substring(1);
            var el = elementList[tag];
            foreach (var ee in el)
            {
                var o = ee.Get();
                if (o != null)
                {
                    materials.Add(o as Material);
                }
                else
                {
                    var mms = CalculateMaterial(ee);
                    materials.AddRange(mms);
                }
            }
            return materials.SimplifyMaterial();
       }


        private object GetMaterial(XmlElement element)
        {
            var materials = new List<Material>();
            var nl = element.GetElementsByTagName("instance_effect");
            foreach (XmlElement xmlElement in nl)
            {
                if (xmlElement.ParentNode == element)
                { ///INSTANCE
                    return xmlElement.Get();
                 }
            }
            return materials.ToMaterial();
        }

        Material FromEnumerable(IEnumerable<Material> materials)
        {
            var l = materials.ToArray();
            if (l.Length == 0)
            {
                return null;
            }
            if (l.Length == 1)
            {
                return l[0];
            }
            return l.ToMaterial();
          }

           XmlElement GetImageFromTexture(string textureName)
        {
            return null;
        }

        object GetImage(XmlElement element)
        {
            ImageSource im = element.InnerText.ToImage();
            if (im == null)
            {
                return false;
            }
            return im;
        }

        object GetSource(XmlElement element)
        {
            var l = new List<object>();
            foreach (string key in sourceDic.Keys)
            {
                XmlElement e = element.GetChild(key);
                if (e != null)
                {
                    object o = sourceDic[key](e);
                    if (o != null)
                    {
                        l.Add(o);
                    }
                }
            }
            if (l.Count > 0)
            {
                if (l.Count == 1)
                {
                    return l[0];
                }
                return l;
            }
            throw new Exception();
        }
    }
}
