using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    public class TypeXmlDesktopTaskProvider : IDesktopTaskProvider
    {
        Task<IDesktop> IDesktopTaskProvider.Get(string name)
        {
            var xml = new XmlDocument();
            xml.LoadXml(name);
            var d = xml.DocumentElement.GetAttribute("Desktop");
            var t = Type.GetType(d);
            var ds = t.GetConstructor(new Type[] { }).Invoke(new object[0]) as IDesktop;
            return Task.FromResult(ds);
        }

        string IDesktopTaskProvider.GetTask(string name)
        {
            throw new ErrorHandler.WriteProhibitedException();
        }
    }
}
