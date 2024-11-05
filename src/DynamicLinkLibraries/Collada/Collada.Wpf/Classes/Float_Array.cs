using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("float_array", true)]
    internal class Float_Array : XmlHolder
    {
        static public readonly string Tag = "float_array";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;

        public float[] Array { get; private set; }

        private Float_Array(XmlElement element) : base(element)
        {
            Array = element.ToRealArray<float>();
        }

        object Get()
        {
            return Array;
        }

        public static object Get(XmlElement element)
        {
            var a = new Float_Array(element);
            return a.Get();
        }
    }
}
