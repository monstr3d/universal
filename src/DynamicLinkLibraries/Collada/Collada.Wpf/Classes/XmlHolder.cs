using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class XmlHolder : Collada.XmlHolder
    {
        protected XmlHolder(XmlElement element) : base(element) 
        {
            element.CheckSource();
        }
    }
}
