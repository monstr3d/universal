
using System;
using System.Collections.Generic;
using System.Linq;
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


        List<Node> childern = new();

        public Node Parent { get; private set; }

        public static List<Node> roots = new();

        bool isCombined = false;

        public string Name { get; private set; }

        public string Id { get; private set; }

        public InstanceGeomery InstanceGeomery { get; private set; }

        void CombineIttelf()
        {
            var x = Xml;
            /*            var url = Xml.GetAttribute("url");
                        if (url.Length > 1)
                        {
                            var g = url.Get<GeometryObject>();

                        }
                        else
                        {
                            throw new System.Exception();
                        } */

            InstanceGeomery = x.Get<InstanceGeomery>();
            InstanceGeomery.Combine();

        }

        private Node(XmlElement element) : base(element)
        {
            Id  = element.GetAttribute("id");
            Name = element.GetAttribute("name");

            var nk = element.GetElements().Where(e => e.ParentNode == element & e.Name == Tag);
            if (!roots.Contains(this))
            {
                roots.Add(this);
            }
            foreach (XmlElement xmlElement in nk)
            {
                var child = xmlElement.Get() as Node;
                child.Parent = this;
                childern.Add(child);
                if (roots.Contains(child))
                {
                    roots.Remove(child);
                }
            }
            Combine();
       }

        static internal void Clear()
        {
            roots.Clear();
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
            CombineIttelf();
            isCombined = true;
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Node(element);
            return a.Get();
        }
    }
}