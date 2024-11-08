using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("input")]
    public class Input: XmlHolder
    {

        public Dictionary<string, object> Semantic => dictionary;

        Dictionary<string, object> dictionary = new();

     

        private Input(XmlElement element) : base(element)
        {
           var  semantic = element.GetAttribute("semantic");
            var source = element.GetAttribute("source").Substring(1);
            if ((semantic.Length == 0) | (source.Length == 0))
            {
                throw new Exception();
            }
            var o = semantic.GetSemantic(source);
            if (o == null)
            {
                throw new Exception();
            }
            dictionary[semantic] = o;

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