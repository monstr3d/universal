using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Collada.Converters.Classes.Elementary;
using Collada;

namespace Collada.Converters.Classes.Complicated
{
    internal class FloatWrapper : Collada.XmlHolder
    {
        public double Value { get; private set; }
        protected FloatWrapper(XmlElement xmlElement) : base(xmlElement)
        {
            Value = xmlElement.Get<FloatObject>().Value;

        }
    }
}
