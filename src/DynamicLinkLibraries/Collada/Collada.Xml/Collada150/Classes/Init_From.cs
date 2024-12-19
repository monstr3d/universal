using System;
using System.Xml;

using Collada;

namespace Collada150.Classes
{
    [Tag("init_from")]
    public class Init_From : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Init_From>();
        
        public ImageSource ImageSource { get; private set; }

        private Init_From(XmlElement element) : base(element)
        {
            var im = element.InnerText.Get<Image>();
            if (im != null)
            {
                ImageSource = im.ImageSource;
            }
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Init_From(element);
            return a.Get();
        }
    }
}
