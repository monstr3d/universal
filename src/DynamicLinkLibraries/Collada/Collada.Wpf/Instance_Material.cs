using System.Xml;

namespace Collada.Wpf
{
    internal class Instance_Material : XmlHolder
    {
        public static readonly string Tag = "instance_material";

        private Instance_Material(XmlElement element) : base(element) 
        { 
        
        }

        static public object Get(XmlElement element)
        {
            return new Instance_Material(element);
        }

    }
}
