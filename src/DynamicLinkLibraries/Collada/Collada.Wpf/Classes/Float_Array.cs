using System.Xml;
using System.Collections.Generic;

namespace Collada.Wpf.Classes
{
    [Tag("float_array", true)]
    internal class Float_Array : XmlHolder
    {
        static Float_Array()
        {
        }


   
        public float[] Array { get; private set; }

        private Float_Array(XmlElement element) : base(element)
        {
            Array = element.InnerText.ToRealArray<float>();
        //    var p = element.GetStatic<Float_Array>();
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<Float_Array>();

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
