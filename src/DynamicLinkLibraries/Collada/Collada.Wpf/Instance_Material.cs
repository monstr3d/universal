using System.Security.Policy;
using System.Xml;

namespace Collada.Wpf
{
    [Tag("instance_material")]
    internal class Instance_Material : XmlHolder
    {
 
        private Instance_Material(XmlElement element) : base(element)
        {
            var url = element.GetAttribute("url");
            if (url.Length > 0)
            {

            }
            else
            {

            }
 
        }

        static public object Get(XmlElement element)
        {
            return new Instance_Material(element);
        }

    }
}
