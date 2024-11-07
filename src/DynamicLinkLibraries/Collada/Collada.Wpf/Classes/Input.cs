using System;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("input", true)]
    internal class Input: XmlHolder
    {


        public string Semantic { get; private set; }

        public string Source { get; private set; }

        private Input(XmlElement element) : base(element)
        {
            Semantic = element.GetAttribute("semantic");
            Source = element.GetAttribute("source");
            if ((Semantic.Length == 0) | (Source.Length == 0))
            {
                throw new Exception();
            }

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Input(element);
            return a.Get();
        }
    }
}