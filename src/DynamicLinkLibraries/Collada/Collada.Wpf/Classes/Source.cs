using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("source")]
    public class Source : Collada.XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Source>();



    

        public string Name { get; private set; }
        Dictionary<XmlElement, object> children;

        public float[] Array { 
            get; 
            private set; 
        }


        public object[] Children { get; private set; }

        protected Source(XmlElement element) : base(element)
        {
      //      Name = element.InnerText;
            try
            {
               var a = element.Get<Float_Array, float[]>();
                if (a != null)
                {
                    Array = a;
                }
                children = new Dictionary<XmlElement, object>(); ;
                // element.AllDictionary(children);
                if (children.Count != 0)
                {

                }
            }
            catch (Exception e)
            {

            }
        }

        protected object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Source(element);
            return a.Get();
        }
    }
}