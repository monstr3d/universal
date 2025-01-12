using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada150.Classes.Abstract
{
    internal class Wrap : XmlHolder
    {

        internal string Text { get; private set; }

        protected Wrap(XmlElement element) : base(element, null)
        {
            Text = element.InnerText;
        }
    }
}
