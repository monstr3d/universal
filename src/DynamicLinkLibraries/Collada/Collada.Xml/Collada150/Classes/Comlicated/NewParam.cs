using System.Xml;
using System;
using System.Collections.Generic;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("newparam")]
    public class NewParam : Collada.XmlHolder
    {
        static public readonly string Tag = "newparam";

        static public Dictionary<Sid, NewParam> inverse = new();

        static public Dictionary<NewParam, Sid> direct = new();



        public Sid Sid { get; internal set; }

        public string Name { get; private set; }

        private NewParam(XmlElement element) : base(element)
        {
            Name = element.GetAttribute("sid");
            Sid = element.FirstElement().Get() as Sid;
            if (Sid == null)
            {
                throw new Exception();
            }
            inverse[Sid] = this;
            direct[this] = Sid;
            Sid.Set(this);

        }

        internal static void Clear()
        {
            direct.Clear();
            inverse.Clear();
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new NewParam(element);
            return a.Get();
        }
    }
}