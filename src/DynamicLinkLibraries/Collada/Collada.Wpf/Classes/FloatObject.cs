using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("float", true)]
    internal class FloatObject : XmlHolder
    {
        static public readonly string Tag = "float";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;



        public float Value { get; private set; } = 0;

        private FloatObject(XmlElement element) : base(element)
        {
            Value = element.InnerText.ToFloat();
        }

        object Get()
        {
            return Value;
        }

        public static object Get(XmlElement element)
        {
            var a = new FloatObject(element);
            return a.Get();
        }
    }
}