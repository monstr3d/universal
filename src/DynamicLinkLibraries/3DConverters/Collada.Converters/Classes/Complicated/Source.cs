using System;
using System.Collections.Generic;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada.Converters.Classes.Elementary;
using Collada.Converters.MeshCreators;


namespace Collada.Converters.Classes.Complicated
{
    [Tag("source")]
    public class Source : Collada.XmlHolder
    {

 
        public string Name { get; private set; }

        internal string Text { get; private set; }

        public float[] Array { get; private set; }

        public object[] Children { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Source>();



        protected Source(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            var creator = meshCreator as ColladaMeshCreator;
            creator.Sources[element.GetAttribute("id")] = this;
            try
            {
                Text = element.InnerText;
                var arr = element.Get<Float_Array>();
                if (arr != null)
                {
                    Array = arr.Array;
                }
            }
            catch (Exception e)
            {
                e.HandleException();
            }
        }

        protected object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Source(element, meshCreator);
            return a.Get();
        }
    }
}