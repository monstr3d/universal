
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("node")]
    public class Node : XmlHolder
    {
        static public readonly string Tag = "node";

        public List<Node> Chidren => childern;

        public static List<Node> Roots => roots;

        public List<Visual3D> Visual3Ds => visual3Ds;

        static Dictionary<XmlElement, Node> dic = new();

        List<Node> childern = new();

        public Node Parent { get; private set; }

        public GeometryObject Geometry { get; private set; }

        public Visual3D Visual3D { get; private set; }

        public static List<Node> roots = new();

        bool isCombined = false;

        public string Name { get; private set; }

        public string Id { get; private set; }

        public InstanceGeomery InstanceGeomery { get; private set; }

        List<Visual3D> visual3Ds = new();

        internal static void Clear()
        {
            dic.Clear();
            roots.Clear();
        }

        public ModelVisual3D Result
        {
            get
            {
                ModelVisual3D m = new ModelVisual3D();
                var l = GetVisual3D();
                foreach (var i in l)
                {
                    m.Children.Add(i);
                }
                return m;
            }
        }

        List<Visual3D> GetVisual3D()
        {
            var vis = Visual3D as ModelVisual3D;
            if (vis != null)
            {
                if (childern.Count == 0)
                {
                    return new() { vis };
                }
            }
            var l = new List<Visual3D>();
            foreach (var child in childern)
            {
                l.AddRange(child.GetVisual3D());
            }
            if (vis == null)
            {
                return l;
            }
            return null;
        }


  



        private Node(XmlElement element) : base(element)
        {
            Id = element.GetAttribute("id");
            Name = element.GetAttribute("name");
            Geometry = GeometryObject.Get(Name);
            if (Geometry != null)
            {
                Visual3D = Geometry.Visual3D;
            }
            var nk = element.GetElements().Where(e => e.ParentNode == element & e.Name == Tag);
            if (!roots.Contains(this))
            {
                roots.Add(this);
            }
            foreach (XmlElement xmlElement in nk)
            {
                var child = new Node(xmlElement);
                dic[xmlElement] = child;
                child.Parent = this;
                childern.Add(child);
            }
 
        }

 
        void Combine()
        {
            if (isCombined)
            {
                return;
            }
            foreach (var child in childern)
            {
                child.Combine();
            }
            CombineItself();
            isCombined = true;
        }

        void CombineItself()
        {

            var x = Xml;
            if (Chidren.Count == 0)
            {
                InstanceGeomery = x.Get<InstanceGeomery>();
                if (InstanceGeomery == null)
                {
                    throw new Exception();
                }
                InstanceGeomery.Combine();
            }
            else
            {
                return;
                foreach (var node in Chidren)
                {
                    var v3d = node.Visual3D;
                    if (v3d != null)
                    {
                        visual3Ds.Add(v3d);
                    }
                    else
                    {
                        visual3Ds.AddRange(node.Visual3Ds);
                    }
                }
            }
            if (Visual3D != null)
            {
                if (visual3Ds.Count > 0)
                {
                }
            }
        }



        object Get()
        {
            return this;
        }

        static Node parent = null;

        public static object Get(XmlElement element)
        {
            if (dic.ContainsKey(element))
            {
                return dic[element];
            }
            var a = new Node(element);
            a.Combine();
            StaticExtensionColladaWpf.Result = a.Result;
            return a.Get();
        }
    }
}