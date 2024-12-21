using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada150.Classes.Abstract;
using System.Xml;

namespace Collada150.Classes.Comlicated
{
  
    [Tag("specular")]
    internal class Specular : ColorWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Specular>();

        private Specular(XmlElement element) : base(element)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Specular(element);
            return a.Get();
        }
    }
}

