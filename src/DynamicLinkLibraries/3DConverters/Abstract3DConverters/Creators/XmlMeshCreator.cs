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

        protected XmlMeshCreator(string filename, byte[] bytes)
        {
            directory = filename.GetDirectory();
            Load(bytes);
        }

        public override void Load(byte[] bytes)
        {
            using var stream = new MemoryStream(bytes);

            using var reader = new StreamReader(stream);
            var s = reader.ReadToEnd();
            doc = new XmlDocument();
            doc.LoadXml(s);
            CreateAll();
        }

    }

}
