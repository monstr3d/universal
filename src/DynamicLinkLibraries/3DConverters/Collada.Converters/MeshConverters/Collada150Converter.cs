using System.Xml;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Meshes;

namespace Collada.Converters.MeshConverters
{
    [Converter(".dae", "1.5.0")]
    public class    Converter150 : ColladaMeshConverter
    {
        #region Fields


        Dictionary<string, int> dm = new();


        #endregion

        #region Constructor

        public Converter150() : base("http://www.collada.org/2008/03/COLLADASchema")
        {
            doc.LoadXml(Properties.Resources.etalon2008);
            var r = doc.GetElementsByTagName("library_visual_scenes")[0];
            library_visual_scenes = doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
            materialCreator = new EmptyXmlMaterialCreator(doc, xmlns, images);
            nodes = doc.GetElementsByTagName("instance_visual_scene")[0] as XmlElement; 
        }


        #endregion      

 
        protected override XmlElement Create(AbstractMesh mesh)
        {
            if (mesh is AbstractMeshPolygon mp)
            {
                mp.CreateTriangles();
            }
            var node = Create("node");
            var pmesh = Process(node, mesh);
         //   mesh.Children.Select(e => Create(node, e)).ToList();
            nodesDic[mesh] = node;
            if (mesh.Vertices != null)
            {
                var ig = Create("instance_geometry");
                ig.SetAttribute("url", "#" + pmesh);
                var mt = mesh.Material;
                if (mt != null)
                {
                    var bm = Create("bind_material");
                    ig.AppendChild(bm);
                    var tc = Create("technique_common");
                    bm.AppendChild(tc);
                    var im = Create("instance_material");
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


    }
}
