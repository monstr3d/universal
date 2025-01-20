using System;
using System.Xml;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Creators
{
    public abstract class XmlMeshCreator : AbstractMeshCreator
    {
        protected XmlDocument doc;

 
        public Dictionary<XmlElement, IParent> Meshes { get; private set; } = new();

        protected string String
        {
            get;
            private set;
        }

        protected XmlMeshCreator(XmlDocument doc)
        {
            this.doc = doc;
        }

        protected XmlMeshCreator(string str)
        {
            String = str;
            doc = new XmlDocument();
            doc.LoadXml(str);
        }

        protected XmlMeshCreator(Stream stream)
        {

        }

        public override void Load(Stream stream)
        {
         /*   using (var reader = new StreamReader(stream))
            {
                var s = reader.ReadToEnd();
                doc = new XmlDocument();
                doc.LoadXml(s);
            }*/
        }

    }

 }
