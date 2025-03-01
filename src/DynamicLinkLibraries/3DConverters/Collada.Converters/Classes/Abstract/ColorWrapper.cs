using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada.Converters.Classes.Elementary;

namespace Collada.Converters.Classes.Abstract
{
    internal class ColorWrapper : XmlHolder
    {
        internal Color Color { get; private set; }

        protected ColorWrapper(XmlElement element) : base(element, null)
        {
           Color =  element.Get<ColorObject>().Color;
        }
    }
}
