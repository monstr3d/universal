using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf
{
    internal class Technique : XmlHolder
    {
        static readonly internal string Tag = "technique_common";

        List<object> children = new List<object>();

        private Technique(XmlElement element) : base(element)
        {
            foreach (XmlElement node in element.GetElements())
            {
                if (node == element)
                {
                    continue;
                }
                var child = node.Get();
                if (child == null)
                {
                    throw new ArgumentException();
                }
                children.Add(child);
            }
        }

        static internal object Get(XmlElement element)
        {
            return new Technique(element);
        }
    }
    // "technique_common
}
