using System.Xml;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Creators
{
    public abstract class XmlMeshCreator : AbstractMeshCreator
    {
        protected XmlDocument doc;

        internal Dictionary<string, Image> InternalImages => Images;


        internal Dictionary<string, Material> InternalMaterials => Materials;
   

        public Dictionary<XmlElement, IParent> MeshesParent 
        { 
            get; 
            private set; 
        } = new();

        protected string String
        {
            get;
            private set;
        }

        protected XmlMeshCreator(string filename, XmlDocument doc) : base(filename)
        {
            this.doc = doc;
        }

        protected XmlMeshCreator(string filename, byte[] bytes) : base(filename)
        {
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
