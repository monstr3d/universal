using System;
using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("source")]
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
            try
            {
                //Children = element.GetOwnChilden<object>().ToArray();
            }
            catch (Exception e)
            {

            }
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