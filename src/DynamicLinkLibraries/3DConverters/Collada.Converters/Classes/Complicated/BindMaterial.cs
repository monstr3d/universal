﻿using System.Xml;
using System;
using Collada;
using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("bind_material")]
    public class BindMaterial : XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<BindMaterial>();


        public Abstract3DConverters.Materials.Effect Effect 
        { 
            get; 
            private set; 
        }
        private BindMaterial(XmlElement element) : base(element, null)
        {
            var inst = element.Get<Instance_Material>();
            if (inst == null)
            {
                return;
            }
            Effect = inst.Effect;

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new BindMaterial(element);
            return a.Get();
        }
    }
}