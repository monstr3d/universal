using System.Xml;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using NamedTree;

namespace Abstract3DConverters.Creators
{
    public abstract class XmlMeshCreator : AbstractMeshCreator
    {
        protected XmlDocument doc;

        protected NamedTree.Performer p = new NamedTree.Performer();

        internal Dictionary<string, Image> InternalImages => Images;


        internal Dictionary<string, Material> InternalMaterials => Materials;
   

        public Dictionary<XmlElement, INode<IMesh>> MeshesParent 
        { 
            get; 
            private set; 
        } = new();

        protected string String
        {
            get;
            private set;
        }

        protected XmlMeshCreator(string filename, string directory, XmlDocument doc) : base(filename, directory)
        {
            this.doc = doc;
        }

        protected XmlMeshCreator(string filename, string directory, byte[] bytes) : base(filename, directory, bytes)
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
