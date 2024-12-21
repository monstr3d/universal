using System.Xml;
using System.Collections.Generic;
using Collada;
using Abstract3DConverters.Interfaces;

namespace Collada150.Classes
{
    [Tag("float_array", true)]
    internal class Float_Array : XmlHolder
    {
        static Float_Array()
        {
        }


   
        public float[] Array { get; private set; }

        private Float_Array(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Array = element.InnerText.ToRealArray<float>();
        //    var p = element.GetStatic<Float_Array>();
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<Float_Array>();

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Float_Array(element, null);
            return a.Get();
        }

    
    }
}
