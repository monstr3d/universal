using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters;

namespace Collada150
{
    public static class StaticExtensionCollada150
    {
        static Service s = new Service();

        static public Color GetColor(this XmlElement e)
        {
            if (e.Name.Equals("color"))
            {
               return new Color(e.InnerText);
            }
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n.Name.Equals("color"))
                {
                    return (n as XmlElement).GetColor();
                }
            }
            throw new Exception();
        }

        static public XmlElement GetColorXml(this XmlElement e)
        {
            if (e.Name == "color")
            {
                return e;
            }
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n.Name.Equals("color"))
                {
                    return (n as XmlElement);
                }
            }
            return null;
        }

    }
}
