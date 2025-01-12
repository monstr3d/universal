using System;
using System.Xml;
using Abstract3DConverters.Interfaces;

namespace Collada.Wpf.Classes
{
    [Tag("A")]
    internal class A : XmlHolder
    {
 
  

        private A(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator mesh)
        {
            var a = new A(element);
            return a.Get();
        }
    }
}