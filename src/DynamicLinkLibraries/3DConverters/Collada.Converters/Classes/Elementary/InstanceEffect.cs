using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Collada;
using System.Xml;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("instance_effect", true)]
    internal class InstanceEffect : Collada.XmlHolder
    {

        internal string Url { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<InstanceEffect>();


        private InstanceEffect(XmlElement element) : base(element)
        {
            Url = element.GetAttribute("url");
        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new InstanceEffect(element);
            return a;
        }
    }
}