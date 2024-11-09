using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("bind_material")]
    internal class BindMaterial : XmlHolder
    {
 
        
        private BindMaterial(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new BindMaterial(element);
            return a.Get();
        }
    }
}