using Abstract3DConverters.Creators;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Xml;

namespace Abstract3DConverters.Meshes
{
    class AbstractMeshXaml : AbstractMesh
    {
        XmlElement element;
        XamlMeshCreator meshCreator;
        Dictionary<string, Action<XmlElement>> actions;
        Dictionary<string, Action<XmlElement>> content;
        Dictionary<string, Action<XmlElement>> geometry;
        Dictionary<string, Action<XmlElement>> geometryGeometry;
        Dictionary<string, Action<XmlElement>> masGeometry;
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

            geometry = new Dictionary<string, Action<XmlElement>>()
            {
                 {"GeometryModel3D.Geometry", ParseGeomertryGeometry},
                                  {"GeometryModel3D.Material", ParseMaterial},

            };

    
            geometryGeometry = new Dictionary<string, Action<XmlElement>>()
            {
                {"MeshGeometry3D" , ParseMeshGeometry}
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


        void ParseMaterial(XmlElement e)
        {
            var ch = e.GetElementsByTagName("MaterialGroup.Children")[0];
            var mg = new 

        }


        void ParseMeshGeometry(XmlElement e)
        {
            var pos = e.GetAttribute("Positions");
            if (pos.Length > 0)
            {
                Vertices = s.ToRealArray<float>(pos, 3);

            }
            var txt = e.GetAttribute("TextureCoordinates");
            if (txt.Length > 0)
            {
                var t = s.ToRealArray<float>(txt, 2);
                Textures = new List<float[]>();
                foreach (var x in t)
                {
                    Textures.Add([x[0], -x[1]]);
                }
            }
            if (Vertices != null)
            {
                var c = Vertices.Count;
                if (c > 0)
                {

                    Indexes = new List<int[][]>();
                    for (int i = 0; i < c; i++)
                    {
                        int[][] k = new int[3][];
                        for (int j = 0; j < 3; j++)
                        {
                            var l = 3 * i + j;
                            k[j] = [l, l, -1];
                        }
                        Indexes.Add(k);
                    }

                }
            }
        }




        void ParseGeomertryGeometry(XmlElement e)
        {
            ParseChildren(e, geometryGeometry);
        }


        void ParseTransformation(XmlElement e)
        {

        }


        void ParseGeometry(XmlElement e)
        {
            ParseChildren(e, geometry);
        }
        void ParseEmpty(XmlElement e)
        {

        }

 

        void ParseContent(XmlElement e)
        {
            ParseChildren(e, content);
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

        void Parse(XmlElement element, Dictionary<string, Action<XmlElement>> dictionary)
        {
            var name = element.Name;
            if (!dictionary.ContainsKey(name))
            {
                throw new Exception("PARSE XAML " + name);
            }
            dictionary[name](element);
        }

        void ParseChildren(XmlElement element, Dictionary<string, Action<XmlElement>> dictionary)
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
                    Parse(e, dictionary);
                }
            }
        }

    }
}
