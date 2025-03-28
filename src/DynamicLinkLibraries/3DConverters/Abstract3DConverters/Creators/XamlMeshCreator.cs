using Abstract3DConverters.Meshes;
using System.Xml;


namespace Abstract3DConverters.Creators
{

    [Attributes.Extension([".xaml"], true)]
    public class XamlMeshCreator : XmlMeshCreator
    {
        #region Fields

        int mn = 0;

        int mat = 0;

        List<AbstractMesh> list = new();

        #endregion

        #region Ctor

        public XamlMeshCreator(string filename, string directory, byte[] bytes) : base(filename, directory, bytes)
        {

        }

   
        #endregion

        internal string MeshName
        {
            get
            {
                ++mn;
                return "Mesh_" + mn;
            }
        }

        internal string MaterialName
        {
            get
            {
                ++mat;
                return "Material" + mn;
            }
        }

        protected override void CreateAll()
        {
            var nl = doc.DocumentElement.GetElementsByTagName("ModelVisual3D");
            foreach (var n in nl)
            {
                var e = n as XmlElement;
                if (e.ParentNode != doc.DocumentElement)
                {
                    continue;
                }
                var am = new AbstractMeshXaml(this, e);
                list.Add(am);
            }
        }


        protected override IEnumerable<AbstractMesh> Meshes => list;
    }

}
