using System;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("A")]
    internal class A : XmlHolder
    {


        public static IClear Clear => StaticExtensionCollada.GetClear<A>();


        private A(XmlElement element) : base(element, null)
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