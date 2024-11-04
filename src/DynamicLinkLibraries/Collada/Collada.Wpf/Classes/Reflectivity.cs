using System;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Reflectivity : XmlHolder
    {
        static public readonly string Tag = "reflectivity";

        public object Value { get; private set; }

        private Reflectivity(XmlElement element) : base(element)
        {
            try
            {
                var fc = element.FirstChild;
                if (fc != null)
                {

                    Value = (element.FirstChild as XmlElement).Get();
                }
                else
                {

                }
            }
            catch (Exception  ex)
            {

            }
        }

        object Get()
        {
            return Value;
        }

        public static object Get(XmlElement element)
        {
            var a = new Reflectivity(element);
            return a.Get();
        }
    }
}