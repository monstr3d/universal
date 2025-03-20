using System.Text;
using System.Xml;

using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;



namespace Abstract3DConverters.Converters
{
    [Converter(".xaml", true)]
    public class XamlMeshConverter : XmlMeshConverter
    {

   
        XamlMaterialCreator xamlMaterial;

        protected override IMaterialCreator MaterialCreator => xamlMaterial;


        public XamlMeshConverter() : base("http://schemas.microsoft.com/winfx/2006/xaml/presentation", null)
        {
            doc.LoadXml(Properties.Resources.xaml);
            nodes = doc.DocumentElement;
            xamlMaterial  = new XamlMaterialCreator(doc, xmlns, new Dictionary<string, object>());
        }

        protected override void SetEffect(XmlElement mesh, XmlElement material)
        {

        }

        private XmlElement Prepare(IMesh mesh)
        {
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
                var max = Converter.MaterialCreator.Create(mat) as XmlElement;
                mr.AppendChild(max);
            }
            return x;
        }


        protected override XmlElement CreateXmlMesh(IMesh mesh)
        {
            var dt = new Dictionary<int, float[]>();
            var x = Create("ModelVisual3D", mesh.Name);
            if (mesh.Polygons == null)
            {
                return x;
            }
            var y = Create("ModelVisual3D.Content");
            x.AppendChild(y);
            var z = Create("GeometryModel3D");
            var mat = mesh.Effect;
            if (mat != null)
            {
                var mr = Create("GeometryModel3D.Material");
                z.AppendChild(mr);
                var max = Converter.MaterialCreator.Create(mat) as XmlElement;
                if (max != null)
                { //!!!DELETE
                    mr.AppendChild(max);
                }
            }
            y.AppendChild(z);
            var w = Create("GeometryModel3D.Geometry");
            z.AppendChild(w);
            var v = Create("MeshGeometry3D");
            w.AppendChild(v);
            var lv = new List<float>();
            var lt = new List<float>();
            var ln = new List<float>();
            foreach (var polygon in mesh.Polygons)
            {
                var points = polygon.Points;
                if (points.Length != 3)
                {
                    ("Illegal Xaml Polygon dimension = " + points.Length).Log(-1);
                }
                foreach (var point in points)
                {
                    lv.AddRange(point.Vertex);
                    var tx = point.Texture;
                    lt.Add(tx[0]);
                    lt.Add(1f - tx[1]);
                    var n = point.Normal;
                    if (n != null)
                    {
                        ln.AddRange(n);
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
            /*       foreach (var pl in mesh.Polygons)
                   {
                       foreach (var pll in pl.Points)
                       {
                           sb.Append(" " + pll.VertexIndex);
                       }
                   }*/
            for (var i = 0; i < mesh.Polygons.Count * 3; i++)
            {
                sb.Append(" " + i);
            }
            var str = sb.ToString();
            if (str.Length > 0)
            {
                v.SetAttribute("TriangleIndices", str.Substring(1));
            }
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




        protected XmlElement CreateXmlMeshOrdinary(IMesh mesh)
        {
            return null;
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
                var max = Converter.MaterialCreator.Create(mat) as XmlElement;
                mr.AppendChild(max);
            }
            var v = Create("MeshGeometry3D");
            w.AppendChild(v);
            var pts = mesh.Vertices;
            if (pts == null)
            {
                return x;
            }
            if (pts.Count == 0)
            {
                return x;
            }
            var ln = new List<float>();
            var lt = new List<float>();
            var pp = mesh.Polygons;
            var d = new Dictionary<int, float[][]>();
            if (pp != null)
            {
                foreach (var polygon in pp)
                {
                    foreach (var point in polygon.Points)
                    {
                        var ind = point.VertexIndex;
                        if (!d.ContainsKey(ind))
                        {
                            continue;
                        }
                        d[ind] = [point.Texture, point.Normal];
                  }
                }
            }
            var l = new List<int>(d.Keys);
            l.Sort();
            var ltx = new List<float>();
            var lnx = new List<float>();
            for (var ind = 0; ind < l.Count; ind++)
            {
                var t = d[ind];
                ltx.Add(t[0][0]);
                ltx.Add(1f - t[0][1]);
                if (t[1] != null)
                {
                    foreach (var tt in t[1])
                    {
                        lnx.Add(tt);
                    }
                }
            }
            if (pts.Count > 0)
            {
                var lv = s.ToSingleEnumerable(pts);

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
                    sb.Append(" " + pll.VertexIndex);
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


    }

    class XamlMaterialCreator : XmlMaterialCreator
    {

        protected IProcessEffect ProcessEffect
        {
            get;

            private set;
        }


        internal XamlMaterialCreator(XmlDocument doc, string xmlns, Dictionary<string, object> images) :
            base(doc, xmlns, images)
        {
          //  ProcessEffect = new ProcessEffect();
        }

        public override object Create(Effect effect)
        {
            var eff = base.Create(effect);
            var mat = effect.Material;
            if (mat is LambertMaterial lamb)
            {
                var s = (lamb.Attachement as XmlElement).OuterXml;
                int i = -1;
                s.Log(i);
            }
            return eff;
            if (mat.GetType() == typeof(PhongMaterial))
            {
                return base.Create(effect);
            }
            return ProcessEffect.Process(null, effect);
        }



        public override object Create(DiffuseMaterial material)
        {
            var x = Create("DiffuseMaterial");
            SetColor(x, material.Color);
            s.SetColor(x, "AmbientColor", material.AmbientColor);
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

        public override object SetImage(object material, object image)
        {
            try
            {
                if (image == null)
                {
                    return material;
                }
                XmlElement e = material as XmlElement;
                var d = e.GetElementsByTagName("DiffuseMaterial")[0];
                var mat = materials[material];


                foreach (var item in mat.Children)
                {
                    if (item is DiffuseMaterial diffuse)
                    {
                        var im = image as Image;
                        var br = Create("DiffuseMaterial.Brush");
                        d.AppendChild(br);
                        var ibr = Create("ImageBrush");
                        br.AppendChild(ibr);
                        var st = StaticExtensionAbstract3DConverters.UseDirectory ? im.FullPath : im.Name;
                        st = s.TransformPathToPlatfom(st);
                        ibr.SetAttribute("ImageSource", st);
                        ibr.SetAttribute("ViewportUnits", "Absolute");
                        ibr.SetAttribute("Opacity", diffuse.Opacity + "");
                        break;
                    }
                }
                return e;
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("XamlMaterialCreator Set Image");
            }
            return null;
        }


  

        private void SetColor(XmlElement e, Color c)
        {
            s.SetColor(e, "Color",c);
        }
    }

    class ProcessEffect : IProcessEffect
    {
        StreamWriter writer;

        internal ProcessEffect()
        {
            if (File.Exists(@"c:\0\1.txt"))
            {
                File.Delete(@"c:\0\1.txt");
            }
           // writer  = new StreamWriter(@"c:\0\1.txt");

        }

        ~ProcessEffect()
        {
            if (writer != null)
            {
                writer.Flush();
                writer.Close();
            }
        }

        object IProcessEffect.Process(XmlElement element, Effect effect)
        {
            var mat = effect.Material;
            if (writer == null)
            {
                return null;
            }
            if (mat is IAttachement attachement)
            {
                var att = attachement.Attachement;
                if (att is XmlElement e)
                {
                    var x = e.GetElementsByTagName("blinn")[0];
                    writer.Write(x.OuterXml);
                    writer.WriteLine();
                    writer.WriteLine("++++++++++++++++++++++++++++");
                    writer.WriteLine();
                }

            }
            return null;
        }

        protected void Process(XmlElement element, Effect effect)
        {

        }
    }

}
