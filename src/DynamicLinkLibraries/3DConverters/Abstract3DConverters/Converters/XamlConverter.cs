using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Xml;

namespace Abstract3DConverters.Converters
{
    [Converter(".xaml")]
    public class XamlConverter : IMeshConverter, ISaveToStream
    {
        Service s = new();

        private Dictionary<string, Material> materials;

        private Dictionary<string, object> images = new();
        XmlDocument doc = new XmlDocument();

        //private Dictionary<string, object>

        MaterialCreator materialCreator;
 
        public XamlConverter()
        {
            materialCreator = new MaterialCreator(images, doc);
        }

        string IMeshConverter.Directory
        {
            get;
            set;
        }

        Dictionary<string, Material> IMeshConverter.Materials { set => materials = value; }

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

        void IMeshConverter.Add(object mesh, object child)
        {
            var p = mesh as XmlElement;
            var c = child as XmlElement;
            p.AppendChild(c);
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            throw new NotImplementedException();
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            if (mesh is AbstractMeshPolygon p)
            {
                p.CreateTriangles();
            }
            var x = doc.CreateElement("ModelVisual3D");
            var y = doc.CreateElement("ModelVisual3D.Content");
            x.AppendChild(y);
            var z = doc.CreateElement("GeometryModel3D");
            y.AppendChild(z);
            var w = doc.CreateElement("GeometryModel3D.Geometry");
            z.AppendChild(w);
            var v= doc.CreateElement("MeshGeometry3D");
            w.AppendChild(v);
            if (mesh.Indexes != null)
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
            return x;
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            if (material == null)
            {
                return;
            }
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            throw new NotImplementedException();
        }

        void ISaveToStream.Save(object obj, Stream stream)
        {
            var d = obj as XmlDocument;
            using var w = XmlWriter.Create(stream, new XmlWriterSettings
            {
                NewLineChars = "\n",
                Indent = true,
                OmitXmlDeclaration = true

            });
            d.WriteContentTo(w);
        }

        public static bool UseDirectory
        { get; set; } = false;
        
    }

    class MaterialCreator : IdenticalMaterialCreator
    {
        XmlDocument doc;

        Service s = new();

        internal MaterialCreator(Dictionary<string, object> images, XmlDocument doc) :
            base(images)
        {
            this.doc = doc;
        }

       

        public override object Create(DiffuseMaterial material)
        {
            var x = doc.CreateElement("DiffuseMaterial");
            SetColor(x, material.Color);
            s.SetColor(x, "AmbientColor", material.AmbientColor);
            var im = material.Image;
            if (im != null)
            {

                var br = doc.CreateElement("DiffuseMaterial.Brush");
                x.AppendChild(br);
                var ibr = doc.CreateElement("ImageBrush");
                br.AppendChild(ibr);
                var st = XamlConverter.UseDirectory ? im.FullPath : im.Name;
                ibr.SetAttribute("ImageSource", st);
                ibr.SetAttribute("ViewportUnits", "Absolute");
                ibr.SetAttribute("Opacity", (1 - material.Opacity) + "");
            }
            return x;
        }

        public override object Create(EmissiveMaterial material)
        {
            var x = doc.CreateElement("EmissiveMaterial");
            SetColor(x, material.Color);
            return x;
        }

        public override object Create(SpecularMaterial material)
        {
            var x = doc.CreateElement("SpecularMaterial");
            SetColor(x, material.Color);
            x.SetAttribute("SpecularPower", material.SpecularPower + "");
            return x;
        }

    

  

        public override object Create(Material material)
        {
            switch (material)
            {
                case DiffuseMaterial diff:
                    return Create(diff);
                    break;
                case EmissiveMaterial emi:
                    return Create(emi);
                    break;
                case SpecularMaterial spec:
                    return Create(spec);
                    break;
                case MaterialGroup mg:
                    return Create(mg);
                default:
                    return null;
            }
        }

        public override object Create(MaterialGroup material)
        {
            var x = doc.CreateElement("MaterialGroup");
            var y = doc.CreateElement("MaterialGroup.Children");
            x.AppendChild(y);
            foreach (var m in material.Children)
            {
                var z = Create(m) as XmlElement;
                y.AppendChild(z);
            }
            return x;

        }






        public override void Add(object group, object value)
        {
        }

        private void SetColor(XmlElement e, Color c)
        {
            s.SetColor(e, "Color",c);
        }
    }

}
