using System.Xml;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    public abstract class XmlConverter : IMeshConverter, IStringRepresentation, ISaveToStream
    {

        #region Fields

        protected string directory;

        protected Service s = new();

        protected Dictionary<string, Material> materials;

        protected IMeshConverter converter;

        protected IMaterialCreator materialCreator;

        protected  Dictionary<string, object> images = new();
        
        protected XmlDocument doc = new XmlDocument();

        protected string xmlns;

        #endregion

        string IMeshConverter.Directory { get => directory; set => directory = value; }
        Dictionary<string, Material> IMeshConverter.Materials { set => materials = value; }


        #region Ctor

        protected XmlConverter()
        {
            converter = this;
        }


        #endregion

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

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
            var m = mesh as XmlElement;
            var mat = material as XmlElement;
            SetMaterial(m, mat);
            
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            SetTransformation(mesh, transformation);
        }

        string IStringRepresentation.ToString(object obj)
        {
            var stream = new Utf8StringWriter();
            using var w = XmlWriter.Create(stream, new XmlWriterSettings
            {
                //         NewLineChars = "\n",
                Indent = true,
                OmitXmlDeclaration = true,

            });
            var d = obj as XmlDocument;
            d.WriteContentTo(w);
            stream.Flush();

            return stream.ToString();
        }

        void ISaveToStream.Save(object obj, Stream stream)
        {
            var d = obj as XmlDocument;
            using var w = XmlWriter.Create(stream, new XmlWriterSettings
            {
                //         NewLineChars = "\n",
                Indent = true,
                OmitXmlDeclaration = true,

            });
            d.WriteContentTo(w);
        }




        #region Protected

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
                        doc.DocumentElement.AppendChild(e);
                    }
                    else
                    {

                    }
                }
            }
            return doc;

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
