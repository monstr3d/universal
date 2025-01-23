using Abstract3DConverters.Creators;
using System.Linq.Expressions;
using System.Xml;

namespace Abstract3DConverters.Meshes
{
    class AbstractMeshXaml : AbstractMesh
    {
        XmlElement element;
        XamlMeshCreator meshCreator;
        Dictionary<string, Action<XmlElement>> actions;
        Dictionary<string, Action<XmlElement>> content;
        internal AbstractMeshXaml(XamlMeshCreator creator, XmlElement element) : base(creator.MeshName, creator)
        {
            actions = new Dictionary<string, Action<XmlElement>>()
            {
                 {"ModelVisual3D.Transform", ParseTransformation},
                 {"ModelVisual3D", ParseEmpty},
                {"ModelVisual3D.Content", ParseContent }
            };

            content = new Dictionary<string, Action<XmlElement>>()
            {
                 {"GeometryModel3D", ParseGeometry},
            };






            this.element = element;
            meshCreator = creator;
            Parse();

            var nl = element.GetElementsByTagName("ModelVisual3D");
            foreach (var n in nl)
            {
                var e = n as XmlElement;
                if (e.ParentNode == element)
                {
                    new AbstractMeshXaml(this, creator, e);
                }
            }
        }

        private AbstractMeshXaml(AbstractMeshXaml parent, XamlMeshCreator creator, XmlElement element) : this(creator, element)
        {
            Parent = parent;
        }

        void ParseTransformation(XmlElement e)
        {

        }


        void ParseGeometry(XmlElement e)
        {

        }
        void ParseEmpty(XmlElement e)
        {

        }

        void Parse(XmlElement element, Dictionary<string, Action<XmlElement>> dictionary)
        {
            foreach (var n in element.ChildNodes)
            {
                if (n is XmlElement e)
                {
                    if (e.ParentNode != element)
                    {
                        continue;
                    }
                    var name = e.Name;
                    if (!dictionary.ContainsKey(name))
                    {
                        throw new Exception("PARSE XAML " + name);
                    }
                    dictionary[name](element);
                }
            }
        }


        void ParseContent(XmlElement e)
        {
            Parse(e, content);
        }


        void Parse()
        {
            foreach (var node in element.ChildNodes)
            {
                if (node is XmlElement e)
                {
                    if (e.ParentNode != element)
                    {
                        continue;
                    }
                    Parse(e, actions);
                }
            }
        }
    }
}
