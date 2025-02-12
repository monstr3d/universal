using System.Text;
using System.Xml;

using Abstract3DConverters.Attributes;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    [Converter(".xaml")]
    public class XamlMeshConverter : XmlMeshConverter
    {


        public XamlMeshConverter() : base("http://schemas.microsoft.com/winfx/2006/xaml/presentation")
        {
            doc.LoadXml(Properties.Resources.xaml);
            nodes = doc.DocumentElement;
            materialCreator = new XamlMaterialCreator(doc, xmlns, new Dictionary<string, object>());
        }


        protected override XmlElement Create(AbstractMesh mesh)
        {
            mesh.CreateTriangles();
            var dt = new Dictionary<int, float[]>();
            var x = Create("ModelVisual3D", mesh.Name);
            var y = Create("ModelVisual3D.Content");
            x.AppendChild(y);
            var z = Create("GeometryModel3D");
            y.AppendChild(z);
            var w = Create("GeometryModel3D.Geometry");
            z.AppendChild(w);
            var mat = mesh.Effect;
            if (mat != null)
            {
                var mr = Create("GeometryModel3D.Material");
                z.AppendChild(mr);
                var max = materialCreator.Create(mat) as XmlElement;
                mr.AppendChild(max);
            }
            var v = Create("MeshGeometry3D");
            w.AppendChild(v);
            var pts = mesh.Points;
            if (pts == null)
            {
                return x;
            }
            if (pts.Count == 0)
            {
                return x;
            }
            var lv = new List<float>();
            var ln = new List<float>();
            var lt = new List<float>();
            var pp = mesh.Polygons;
            if (pp != null)
            {
                foreach (var polygon in pp)
                {
                    foreach (var point in polygon.Points)
                    {
                        var txt = point.Texture;
                        dt[point.Index] = [txt[0],1f - txt[1]];
                    }
                }
            }
          /*  var lk = new List<int>(dt.Keys);
            lk.Sort();
            foreach (var key in lk)
            {
                var p = dt[key];
                foreach (var pt in p)
                {
                    lt.Add(pt);
                }
            }*/
          for (var ii = 0; ii < mesh.Points.Count; ii++)
            {
                var point = mesh.Points[ii];

                var vt = point.Vertex;
                if (vt != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        lv.Add(vt[i]);
                    }
                    if (!dt.ContainsKey(ii))
                    {
                        lt.Add(0f);
                        lt.Add(0f);
                    }
                    else
                    {
                        var tx = dt[ii];
                        lt.Add(tx[0]);
                        lt.Add(tx[1]);
                    }
                }
                vt = point.Normal;
                if (vt != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        ln.Add(vt[i]);
                    }
                }
            }
            if (lv.Count > 0)
            {
                v.SetAttribute("Positions", s.Parse(lv));
            }
            if (lt.Count > 0)
            {
                v.SetAttribute("TextureCoordinates", s.Parse(lt));
            }
            if (ln.Count > 0)
            {
                v.SetAttribute("Normals", s.Parse(ln));
            }
            var sb = new StringBuilder();
            foreach (var pl in mesh.Polygons)
            {
                foreach (var pll in pl.Points)
                {
                    sb.Append(" " + pll.Index);
                }
            }
            var str = sb.ToString();
            v.SetAttribute("TriangleIndices", str.Substring(1));
            return x;
            var vert = mesh.Vertices;
            if (mesh.Indexes != null & vert != null)
            {
                var count = vert.Count;
                if (count > 0)
                {
                    var points = new List<float>();
                    var norm = new List<float>();
                    var textcoord = new List<float>();

                    foreach (var item in mesh.Indexes)
                    {
                        foreach (var idx in item)
                        {
                            var kp = idx[0];
                            if (kp >= count)
                            {

                            }
                            float[] vr = mesh.Vertices[kp];
                            foreach (var vv in vr)
                            {
                                points.Add(vv);
                            }
                            if (mesh.Textures != null)
                            {
                                kp = idx[1];
                                if (kp >= 0)
                                {
                                    if (kp >= mesh.Textures.Count)
                                    {

                                    }
                                    var vt = mesh.Textures[kp];
                                    textcoord.Add(vt[0]);
                                    textcoord.Add(1 - vt[1]);
                                }
                            }
                            if (mesh.Normals != null)
                            {
                                if (idx.Length > 2)
                                {
                                    kp = idx[2];
                                    if (kp >= 0)
                                    {
                                        var vn = mesh.Normals[kp];
                                        foreach (var vv in vn)
                                        {
                                            norm.Add(vv);
                                        }
                                    }
                                }
                            }
                            if (points.Count > 0)
                            {
                                v.SetAttribute("Positions", s.Parse(points));
                            }
                            if (textcoord.Count > 0)
                            {
                                v.SetAttribute("TextureCoordinates", s.Parse(textcoord));
                            }
                            if (norm.Count > 0)
                            {
                                v.SetAttribute("Normals", s.Parse(norm));
                            }
                        }
                    }

                }
            }

            return x;
        }
  

        protected override void SetTransformation(object mesh, float[] transformation)
        {
            var x = mesh as XmlElement;
            var t = Create("ModelVisual3D.Transform");
            x.AppendChild(t);
            var tr = Create("MatrixTransform3D");
            t.AppendChild(tr);
            if (transformation != null)
            {
                var sb = new StringBuilder();
                foreach (var p in transformation)
                {
                    var st = s.ToString<float>(p) + ",";
                    sb.Append(st);
                }
                var str = sb.ToString();
                str = str.Substring(0, str.Length - 1);
                tr.SetAttribute("Matrix", str);
            }
        }

        protected override void Set(Dictionary<string, Image> images)
        {

        }

        public static bool UseDirectory
        { get; set; }


    }

    class XamlMaterialCreator : XmlMaterialCreator
    {

        internal XamlMaterialCreator(XmlDocument doc, string xmlns, Dictionary<string, object> images) :
            base(doc, xmlns, images)
        {
        }

       

        public override object Create(DiffuseMaterial material)
        {
            var x = Create("DiffuseMaterial");
            SetColor(x, material.Color);
            s.SetColor(x, "AmbientColor", material.AmbientColor);
            if (im != null)
            {

                var br = Create("DiffuseMaterial.Brush");
                x.AppendChild(br);
                var ibr = Create("ImageBrush");
                br.AppendChild(ibr);
                var st = XamlMeshConverter.UseDirectory ? im.FullPath : im.Name;
                ibr.SetAttribute("ImageSource", st);
                ibr.SetAttribute("ViewportUnits", "Absolute");
                ibr.SetAttribute("Opacity", material.Opacity + "");
            }
            return x;
        }

        public override object Create(EmissiveMaterial material)
        {
            var x = Create("EmissiveMaterial");
            SetColor(x, material.Color);
            return x;
        }

        public override object Create(SpecularMaterial material)
        {
            var x = Create("SpecularMaterial");
            SetColor(x, material.Color);
            x.SetAttribute("SpecularPower", material.SpecularPower + "");
            return x;
        }

        public override object Create(MaterialGroup material)
        {
            var n = material.Name;
            var x = Create("MaterialGroup");
            if (n != null)
            {
                if (n.Length > 0)
                {
                  //  x.SetAttribute("x:Key", n);
                }
            }
            var y = Create("MaterialGroup.Children");
            x.AppendChild(y);
            foreach (var m in material.Children)
            {
                var z = Create(m) as XmlElement;
                y.AppendChild(z);
            }
            return x;
        }





        private void SetColor(XmlElement e, Color c)
        {
            s.SetColor(e, "Color",c);
        }
    }

}
