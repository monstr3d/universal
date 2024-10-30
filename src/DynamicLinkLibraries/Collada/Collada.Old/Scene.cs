using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada
{
    internal class Scene
    {
        XmlElement xmlElement;

        public Scene(XmlElement xmlElement)
        {
            this.xmlElement = xmlElement;
        }

        public XmlElement Xml { get =>  xmlElement; }

        public object Object { get; set; }
    }
}