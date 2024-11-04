using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class MinFilter : Source
    {
        static public readonly string Tag = "minfilter";

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