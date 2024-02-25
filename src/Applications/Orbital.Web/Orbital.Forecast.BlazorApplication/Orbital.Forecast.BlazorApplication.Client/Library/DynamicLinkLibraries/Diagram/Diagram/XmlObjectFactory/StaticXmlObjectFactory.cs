using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;

using CategoryTheory;
using Diagram.UI.Interfaces;

namespace Diagram.UI.XmlObjectFactory
{
    /// <summary>
    /// Static Xml object factory
    /// </summary>
    public static class StaticXmlObjectFactory
    {
        /// <summary>
        /// Creates objects from Xml nodes
        /// </summary>
        /// <param name="nodes">Nodes</param>
        /// <param name="factory">Factory</param>
        /// <param name="dictionary">Dictionary</param>
        public static void Create(IEnumerable<XElement> nodes, IXmlObjectFactory factory,
            IDictionary<XElement, ICategoryObject> dictionary)
        {

            foreach (XElement node in nodes)
            {
                if (!(node is XElement))
                {
                    continue;
                }
                XElement e = node as XElement;
                ICategoryObject co = null;
                factory.Create(e, ref co);
                if ((co != null) & (dictionary != null))
                {
                    dictionary[e] = co;
                }
            }
        }

        /// <summary>
        /// Creates existing objects from Xml nodes
        /// </summary>
        /// <param name="nodes">Nodes</param>
        /// <param name="factory">Factory</param>
        /// <param name="dictionary">Dictionary</param>
        public static void CreateExisting(IEnumerable<XElement> nodes,
            IXmlObjectFactory factory, IDictionary<XElement, ICategoryObject> dictionary)
        {
            foreach (XElement node in nodes)
            {
                if (!(node is XElement))
                {
                    continue;
                }
                XElement e = node as XElement;
                if (!dictionary.ContainsKey(e))
                {
                    continue;
                }
                ICategoryObject co = dictionary[e];
                factory.Create(e, ref co);
            }
        }
    }
}
