using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Diagram
{
    public class TypeXmlDesktopTaskProvider : IDesktopTaskProvider
    {
        IDesktop IDesktopTaskProvider.this[string name]
        {
            get
            {
                var xml = new XmlDocument();
                xml.LoadXml(name);
                var d = xml.DocumentElement.GetAttribute("Desktop");
                var t = Type.GetType(d);
                return t.GetConstructor(new Type[] { }).Invoke(new object[0]) as IDesktop;
            }
        }

        string IDesktopTaskProvider.GetTask(string name)
        {
            throw new NotImplementedException();
        }
    }
}
