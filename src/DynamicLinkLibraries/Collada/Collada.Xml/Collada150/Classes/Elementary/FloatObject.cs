using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Elementary
{
    [Tag("float", true)]
    internal class FloatObject : XmlHolder
    {

        public float Value { get; private set; } = 0;

        public static IClear Clear => StaticExtensionCollada.GetClear<FloatObject>();



        private FloatObject(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Value = element.InnerText.ToFloat();
        }

        object Get()
        {
            return Value;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new FloatObject(element, meshCreator);
            return a.Get();
        }
    }
}