using System.Xml;
using System;

namespace Collada.Wpf
{
    public class Source : XmlHolder
    {
        public readonly static  string Tag = "source";

        public Sid Sid { get; private set; }

        private Source(XmlElement xml) : base(xml)
        {
        }

        public static object Get(XmlElement xml)
        {
            return new Source(xml);
        }

    }
}
