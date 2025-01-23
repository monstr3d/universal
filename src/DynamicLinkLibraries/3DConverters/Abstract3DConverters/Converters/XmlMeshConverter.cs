using System.Text;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    public abstract class XmlMeshConverter : IMeshConverter, IStringRepresentation, ISaveToStream
    {

        #region Fields

        protected string directory;

        protected Service s = new();

        protected Dictionary<string, Material> materials;

        protected IMeshConverter converter;

        protected IMaterialCreator materialCreator;

        protected  Dictionary<string, object> images = new();
        
        protected XmlDocument doc = new XmlDocument();

        protected XmlElement nodes;


        protected string xmlns;

        protected Dictionary<AbstractMesh, XmlElement> nodesDic = new();



        #endregion

        string IMeshConverter.Directory { get => directory; set => directory = value; }
        Dictionary<string, Material> IMeshConverter.Materials { set => Set(value); }

        #region Ctor

        protected virtual void Set(Dictionary<string, Material> materials)
        {
            this.materials = materials;
        }

        protected XmlMeshConverter(string xmlns)
        {
            converter = this;
            this.xmlns = xmlns;
            nodes = doc.DocumentElement;
        }


        #endregion

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

        Dictionary<string, Image> IMeshConverter.Images { set => Set(value); }

        void IMeshConverter.Add(object mesh, object child)
        {
            XmlElement m = mesh as XmlElement;
            XmlElement c = child as XmlElement;
            Add(m, c);
        }


        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            return Combine(meshes);
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            return Create(mesh);
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            SetMaterial(mesh, material);
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            SetTransformation(mesh, transformation);
        }

        string IStringRepresentation.ToString(object obj)
        {
            var stream = new StringWriter();
            using var w = XmlWriter.Create(stream, new XmlWriterSettings
            {
                //         NewLineChars = "\n",
                Indent = true,
            //    OmitXmlDeclaration = true,
           //   Encoding = Encoding.UTF8

            });
            var d = obj as XmlDocument;
            return d.OuterXml;
            d.WriteContentTo(w);
           // stream.Flush();

            return stream.ToString();
        }

        void ISaveToStream.Save(object obj, Stream stream)
        {
            var d = obj as XmlDocument;
            /*  using var w = XmlWriter.Create(stream, new XmlWriterSettings
              {
                  //         NewLineChars = "\n",
                  Indent = true,
             //     OmitXmlDeclaration = true,

              });
              d.WriteContentTo(w);*/
            d.Save(stream);
         
        }




        #region Protected


        protected abstract void Set(Dictionary<string, Image> images);


        protected abstract XmlElement Create(AbstractMesh mesh);

        protected abstract void SetTransformation(object mesh, float[] transformation);

        protected virtual void Add(XmlElement mesh, XmlElement child)
        {
            mesh.AppendChild(child);
        }

        protected virtual XmlDocument Combine(IEnumerable<object> meshes)
        {
            foreach (var r in meshes)
            {
                if (r is XmlElement e)
                {

                    if (e.ParentNode == null)
                    {
                        nodes.AppendChild(e);
                    }
                    else
                    {

                    }
                }
            }
            return doc;

        }

        protected virtual void SetMaterial(object mesh, object material)
        {
            var m = mesh as XmlElement;
            var mat = material as XmlElement;
            SetMaterial(m, mat);

        }

        protected virtual void SetMaterial(XmlElement mesh, XmlElement  material)
        {

        }

        protected XmlElement Create(string tag)
        {
            return doc.CreateElement(tag, xmlns);
        }


        #endregion
    }
}
