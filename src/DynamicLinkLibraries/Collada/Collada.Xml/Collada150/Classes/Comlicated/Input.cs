using System;
using System.Collections.Generic;
using System.Xml;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("input")]
    public class Input : XmlHolder
    {

        public KeyValuePair<string, OffSet> Semantic => dictionary;

        KeyValuePair<string, OffSet> dictionary;

        public static IClear Clear => StaticExtensionCollada.GetClear<Input>();




        private Input(XmlElement element) : base(element)
        {
            int offset = -1;
            var off = element.GetAttribute("offset");

            if (off.Length > 0)
            {
                offset = int.Parse(off);
            }
            var s = element.OuterXml;
            var p = element.Get<P>();
            if (p != null)
            {

            }
            var semantic = element.GetAttribute("semantic");
            var source = element.GetAttribute("source").Substring(1);
            if (semantic.Length == 0 | source.Length == 0)
            {
                throw new Exception();
            }
            var o = semantic.GetSemantic(source);
            if (o == null)
            {
                throw new Exception();
            }
            var offs = new OffSet(offset, o);
            dictionary = new KeyValuePair<string, OffSet>(semantic, offs);
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