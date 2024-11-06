using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class SourceHolder : Collada.XmlHolder
    {
        public bool ContainsSource { get; private set; } = false;

        public SourceHolder(XmlElement element) : base(element) 
        {
            var b =  ContainsSource = element.GetAllElementsByTagName("source").ToArray().Length > 0;
            if (b)
            {
                var s = element.GetAllChildren<Source>().ToArray(); ;
                ContainsSource = true;
            }
            else
            {

            }

        }
    }
}
