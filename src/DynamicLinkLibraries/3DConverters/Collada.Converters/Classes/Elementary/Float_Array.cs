﻿using System.Xml;
using System.Collections.Generic;
using Collada;
using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Elementary
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
            var id = element.GetAttribute("id");
            if (id.Length > 0)
            {
                MeshCreator.Arrays[id] = this;
            }
        //    var p = element.GetStatic<Float_Array>();
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<Float_Array>();

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Float_Array(element, meshCreator);
            return a.Get();
        }

    
    }
}
