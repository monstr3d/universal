using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("minfilter", true)]
    internal class MinFilter : Source
    {
        static public readonly string Tag = "minfilter";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;



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