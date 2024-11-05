using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Source : XmlHolder
    {
        static public readonly string Tag = "source";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;



        public string Name { get; private set; }

        public object[] Children { get; private set; }

        protected Source(XmlElement element) : base(element)
        {
            Name = element.InnerText;
          //  Children = element.GetOwnChilden<object>().ToArray();
        }

        protected object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Source(element);
            return a.Get();
        }
    }
}