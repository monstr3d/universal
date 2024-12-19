using System.Xml;
using Collada;

namespace Collada150.Classes
{
    [Tag("minfilter", true)]
    internal class MinFilter : XmlHolder
    {
 
        private MinFilter(XmlElement element) : base(element)
        {

        }

        


        public static object Get(XmlElement element)
        {
            var a = new MinFilter(element);
            return a.Get();
        }
    }
}