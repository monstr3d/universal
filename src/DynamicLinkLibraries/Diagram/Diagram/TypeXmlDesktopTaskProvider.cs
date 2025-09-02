using System;
using System.Xml;
using Diagram.UI.Interfaces;

namespace Diagram.UI
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
            throw new ErrorHandler.WriteProhibitedException();
        }
    }
}
