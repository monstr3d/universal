using Abstract3DConverters.Attributes;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using System.Xml;

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
            if (mesh is AbstractMeshPolygon p)
            {
                p.CreateTriangles();
            }
            var x = Create("ModelVisual3D");
            var y = Create("ModelVisual3D.Content");
            x.AppendChild(y);
            var z = Create("GeometryModel3D");
            y.AppendChild(z);
            var w = Create("GeometryModel3D.Geometry");
            z.AppendChild(w);
            var v = Create("MeshGeometry3D");
            w.AppendChild(v);
            if (mesh.Indexes != null & mesh.Vertices != null)
            {
                var points = new List<float>();
                var norm = new List<float>();
                var textcoord = new List<float>();
                foreach (var item in mesh.Indexes)
                {
                    foreach (var idx in item)
                    {
                        var kp = idx[0];
                        if (kp >= 0)
                        {
                            float[] vr = mesh.Vertices[kp];
                            foreach (var vv in vr)
                            {
                                points.Add(vv);
                            }
                        }
                        kp = idx[1];
                        if (kp >= 0)
                        {
                            var vt = mesh.Textures[kp];
                            textcoord.Add(vt[0]);
                            textcoord.Add(1 - vt[1]);
                        }
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
            var mat = mesh.Material;
            if (mat != null)
            {
                var mr = Create("GeometryModel3D.Material");
                z.AppendChild(mr);
                var max = materialCreator.Create(mat) as XmlElement;
                mr.AppendChild(max);
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
            var im = material.Image;
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
            var x = Create("MaterialGroup");
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
