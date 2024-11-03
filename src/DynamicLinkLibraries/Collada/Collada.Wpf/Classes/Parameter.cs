using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class Transparent
    {
        XmlElement xml;

        public Color Color { get; private set; }

        public string Opaque { get; private set; }
        public Transparent(XmlElement xml)
        {
            this.xml = xml;
            Color = (Color)(xml.FirstChild as XmlElement).Get();
            Opaque = xml.GetAttribute("opaque");
        }
    }

    public class Texture : XmlHolder, IImageSource
    {


        public Sid Sid { get; private set; }

        public ImageSource ImageSource
        {
            get
            {
                if (Sid is IImageSource iss)
                {
                    return iss.ImageSource;
                }
                return null;
            }
        }

        // public Parameter Parameters { get; private set; }

        //    Parameter pp;
        public Texture(XmlElement xmlElement) : base(xmlElement)
        {
            var texture = xmlElement.GetAttribute("texture");
            //   Parameters = Parameter.Get(texture);
            Sid = Sid.Get(texture);
        }

    }
}