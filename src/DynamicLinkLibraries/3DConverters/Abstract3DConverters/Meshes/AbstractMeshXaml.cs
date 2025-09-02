using Abstract3DConverters.Creators;
using Abstract3DConverters.Materials;
using ErrorHandler;
using NamedTree;
using System.Xml;

namespace Abstract3DConverters.Meshes
{
    
    class AbstractMeshXaml : AbstractMesh
    {

        XmlElement element;
        Dictionary<string, Action<XmlElement>> actions;
        Dictionary<string, Action<XmlElement>> content;
        Dictionary<string, Action<XmlElement>> geometry;
        Dictionary<string, Action<XmlElement>> geometryGeometry;
        XamlMeshCreator meshCreator;

     
        internal AbstractMeshXaml(XamlMeshCreator creator, XmlElement element) : base(null, creator.MeshName, creator)
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
            ProtectedParent = parent;
            meshCreator = creator;
        }

        Color GetColor(XmlElement element, string attr)
        {
            var c = element.GetAttribute(attr);
            if (c.Length == 0)
            {
                return null;
            }
            return new Color(c.Substring(1).ToLower(), true);

        }

        Material GetMaterial(XmlElement element)
        {
            Material mat = null;
            var color = GetColor(element, "Color");
            switch (element.Name)
            {
                case "DiffuseMaterial":
                    var amb = GetColor(element, "AmbientColor");
                    var txt = element.GetElementsByTagName("ImageBrush")[0] as XmlElement;
                    float t = 0;
                    Image im = null;
                    if (txt != null)
                    {
                        var opa = txt.GetAttribute("Opacity");
                        if (opa.Length > 0)
                        {
                            t = s.ToReal<float>(opa);
                        }
                        var ims = txt.GetAttribute("ImageSource");
                        if (ims.Length > 0)
                        {
                            var imgs = meshCreator.InternalImages;
                            if (imgs.ContainsKey(ims))
                            {
                                im = imgs[ims];
                            }
                            else
                            {
                                im = new Image(ims, Creator.Directory);
                                imgs[ims] = im;
                            }
                        }
                    }
                    mat = new DiffuseMaterial(color, amb, 1 - t);
                    break;

                case "EmissiveMaterial":
                    mat = new EmissiveMaterial(color);
                    break;
                case "SpecularMaterial":
                    var sp = element.GetAttribute("SpecularPower");
                    var spp = s.ToReal<float>(sp);
                    mat = new SpecularMaterial(color, spp);
                    break;
            }
            if (mat == null)
            {
                throw new OwnException("MATERIAL " + element.Name);
            }
            return mat;
        }


        void ParseMaterial(XmlElement element)
        {
            var ch = element.GetElementsByTagName("MaterialGroup.Children")[0];
            var name = meshCreator.MaterialName;
            IChildren<SimpleMaterial> mg = new MaterialGroup(name);
            meshCreator.InternalMaterials[name] = mg as Material;
            var mat = ch.ChildNodes;
            foreach (var n in mat)
            {
                if (n is XmlElement e)
                {
                    if (e.ParentNode == ch)
                    {
                        mg.AddChild(GetMaterial(e) as SimpleMaterial);
                    }
                }
            }
            Effect = null;
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
                    Textures.Add([x[0], 1-x[1]]);
                }
            }
            if (Vertices != null)
            {
                var c = Vertices.Count;
                if (c > 0)
                {
                    c = c / 3;

                    Indexes = new List<int[][]>();
                    for (int i = 0; i < c; i++)
                    {
                        int[][] k = new int[3][];
                        for (int j = 0; j < 3; j++)
                        {
                            var l =  3 * i + j;
                            k[j] = [l, l, 0];
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
                throw new OwnException("PARSE XAML " + name);
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

