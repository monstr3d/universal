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

        protected Dictionary<string, Effect> effects = new();



        #endregion

        #region Ctor
        protected XmlMeshConverter(string xmlns)
        {
            converter = this;
            this.xmlns = xmlns;
            nodes = doc.DocumentElement;
        }

        #endregion

        #region Members


        string IMeshConverter.Directory { get => directory; set => directory = value; }
        Dictionary<string, Material> IMeshConverter.Materials { set => Set(value); }

   
        protected virtual void Set(Dictionary<string, Material> materials)
        {
            this.materials = materials;
        }

  
        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

        Dictionary<string, Image> IMeshConverter.Images { set => Set(value); }
        Dictionary<string, Effect> IMeshConverter.Effects { set => throw new NotImplementedException(); }

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

        void IMeshConverter.SetEffect(object mesh, object effect)
        {
            SetEffect(mesh, effect);
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


        #endregion



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

        protected virtual void SetEffect(object mesh, object effect)
        {
            var m = mesh as XmlElement;
            var mat = effect as XmlElement;
            SetEffect(m, mat);

        }

        protected virtual void SetEffect(XmlElement mesh, XmlElement  material)
        {

        }

        protected XmlElement Create(string tag, string name = null)
        {
            var x = doc.CreateElement(tag, xmlns);
            if (name != null)
            {
                if (name.Length > 0)
                {
             //       x.SetAttribute("x:Name", name);
                }
            }
            return x;
        }

  

        #endregion
    }
}
