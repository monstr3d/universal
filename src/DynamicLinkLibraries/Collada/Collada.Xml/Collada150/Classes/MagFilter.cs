using System.Xml;
using Collada;

namespace Collada150.Classes
{
    [Tag("magfilter", true)]
    internal class MagFilter : XmlHolder
    {
        static public readonly string Tag = "magfilter";

   


        private MagFilter(XmlElement element) : base(element)
        {

        }


        public static object Get(XmlElement element)
        {
            var a = new MagFilter(element);
            return a.Get();
        }
    }
}
