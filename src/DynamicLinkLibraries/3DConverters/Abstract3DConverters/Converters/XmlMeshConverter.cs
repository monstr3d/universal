using System.Xml;

using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    
    public abstract class XmlMeshConverter : AbstractMeshConverter, IStringRepresentation, ISaveToStream
    {

        #region Fields

            
        protected XmlDocument doc = new XmlDocument();

        protected XmlElement nodes;


        protected string xmlns;

        protected Dictionary<AbstractMesh, XmlElement> nodesDic = new();



        #endregion

        #region Ctor

        protected XmlMeshConverter(string xmlns, IMaterialCreator materialCreator) : base(materialCreator)
        {
            this.xmlns = xmlns;
            nodes = doc.DocumentElement;
        }

        #endregion

        #region Members

     

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
           d.Save(stream);
         
        }




        #endregion


        #region Protected

        protected override object Combine(IEnumerable<object> meshes)
        {
            return CombineXml(meshes);
        }

        protected override object Create(IMesh mesh)
        {
            base.Create(mesh);
            return CreateXmlMesh(mesh);
        }

        protected abstract XmlElement CreateXmlMeshCV(IMesh mesh);

        protected abstract XmlElement CreateXmlMeshOrdinary(IMesh mesh);


        protected virtual XmlElement CreateXmlMesh(IMesh mesh)
        {
            var at = s.GetAttribute<CommonVetricesAttribute>(mesh);
            if (at != null)
            {
                return CreateXmlMeshCV(mesh);
            }
            return CreateXmlMeshOrdinary(mesh);
        }

        protected virtual XmlElement Create(XmlElement parent, AbstractMesh mesh)
        {
            var x = CreateXmlMesh(mesh);
            parent.AppendChild(x);
            return x;
        }


        protected virtual void Add(XmlElement mesh, XmlElement child)
        {
            if (child != null)
            {
                var nd = mesh.ChildNodes.Cast<object>().ToList();
                if (!nd.Contains(child))
                {
                    mesh.AppendChild(child);
                }
            }
        }

        protected virtual XmlDocument CombineXml(IEnumerable<object> meshes)
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

        protected override void SetEffect(object mesh, object effect)
        {
            var m = mesh as XmlElement;
            var mat = effect as XmlElement;
            SetEffect(m, mat);

        }

        protected abstract void SetEffect(XmlElement mesh, XmlElement material);
 
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

        #region Overriden


        protected override void Add(object mesh, object child)
        {
            XmlElement m = mesh as XmlElement;
            XmlElement c = child as XmlElement;
            Add(m, c);
        }


        #endregion
    }
}
