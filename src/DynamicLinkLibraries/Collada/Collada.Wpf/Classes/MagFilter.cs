using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("magfilter", true)]
    internal class MagFilter : Source
    {
        static public readonly string Tag = "magfilter";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;



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
