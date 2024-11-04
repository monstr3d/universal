using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class Param : XmlHolder
    {
        static public readonly string Tag = "param";

        static Dictionary<string, Type> types = new()
        {
            { "float", typeof(float) },
        };

        public string Name { get; private set; }

        public Type Type { get; private set; }
        private Param(XmlElement element) : base(element)
        {
            Name = element.GetAttribute("name");
            var s = element.GetAttribute("type");
            var t = Type.GetType(s);
            if (t != null)
            {
                Type = t;
                return;
            }
            if (types.ContainsKey(s))
            {
                Type = types[s];
                return;
            }
            throw new Exception();
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Param(element);
            return a.Get();
        }
    }
}