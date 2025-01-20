using System.Xml;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    [Converter(".dae", "1.5.0")]
    public class Collada150Converter : ColladaMeshConverter
    {
        #region Fields


        Dictionary<string, int> dm = new();


        #endregion

        #region Constructor

        public Collada150Converter() : this(null)
        {

        }

        public Collada150Converter(string directory) : base(directory)
        {
            converter = this;
            doc.LoadXml(Properties.Resources.etalon);
            var r = doc.GetElementsByTagName("library_visual_scenes")[0];
            library_visual_scenes = doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
        }

        #endregion

        protected override void SetMaterial(XmlElement mesh, XmlElement material)
        {
        }

        protected override XmlElement Create(XmlElement parent, AbstractMesh mesh)
        {
            if (mesh is AbstractMeshPolygon mp)
            {
                mp.CreateTriangles();
            }
            var node = doc.CreateElement("node");
            parent.AppendChild(node);
            var pmesh = Process(node, mesh);
            mesh.Children.Select(e => Create(node, e)).ToList();
            nodes[mesh] = node;
            if (mesh.Vertices != null)
            {
                var ig = doc.CreateElement("instance_geometry");
                ig.SetAttribute("url", "#" + pmesh);
                var mt = mesh.Material;
                if (mt != null)
                {
                    var bm = doc.CreateElement("bind_material");
                    ig.AppendChild(bm);
                    var tc = doc.CreateElement("technique_common");
                    bm.AppendChild(tc);
                    var im = doc.CreateElement("instance_material");
                    tc.AppendChild(im);
                    im.SetAttribute("symbol", "mat" + nmat);
                    var nm = mt.Name;
                    im.SetAttribute("target", "#" + nm);
                }
                ++nmat;
                node.AppendChild(ig);
            }
            return node;
        }

        protected override void SetTransformation(object mesh, float[] transformation)
        {
        }



    }
}
