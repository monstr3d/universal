using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf
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

    public class Abstract
    {
        protected XmlElement parent;


        protected XmlElement own;

        protected Dictionary<string, List<XmlElement>> keyValues;

        public object Value { get; protected set; }

    }
    public class Source
    {
        public Source(XmlElement xml)
        {
            var c = xml.InnerText;
            var t = c.GetObject();

        }
    }

    public class Sid : XmlHolder
    {
        static Dictionary<string, Sid> dictionary = new();

        static List<string> xml = new();
        public Sid(XmlElement element) : base(element)
        {
            var p = (element.ParentNode as XmlElement);
            var sid = p.GetAttribute("sid");
            if (dictionary.ContainsKey(sid))
            {
                if (!xml.Contains(p.OuterXml))
                {
                    return;
                }
                throw new Exception();
            }
            dictionary[sid] = this;
            xml.Add(p.OuterXml);
        }

        public static Sid Get(string s)
        {
            if (dictionary.ContainsKey(s))
            {
                return dictionary[s];
            }
            throw new Exception();
        }

        public static Sid Get(XmlElement element)
        {
            var p = (element.ParentNode as XmlElement);
            var sid = p.GetAttribute("sid");
            if (dictionary.ContainsKey(sid))
            {
                if (xml.Contains(p.OuterXml))
                {
                    return dictionary[sid];
                }
            }
            return null;
        }

    

        internal static void Clear()
        {
            dictionary.Clear();
            xml.Clear();
        }
    }

    public interface IImageSource
    {
        ImageSource ImageSource { get; }
    }


    public class Surface : Sid, IImageSource
    {

        public ImageSource ImageSource { get; private set; }

        
        public Surface(XmlElement element) : base(element)
        {
            ImageSource = element.InnerText.GetObject() as ImageSource;
            
        }
   
    }

    public class Sampler2D : Sid, IImageSource
    {
        public Surface Surface { get; private set; }

        public ImageSource ImageSource { get; private set; }

        public Sampler2D(XmlElement element) : base(element)
        {
            var f = element.FirstElement();
            Surface  = Sid.Get(f.InnerText) as Surface;
            if (Surface == null)
            {
                throw new Exception();
            }
            ImageSource = Surface.ImageSource;
        }
      /*  protected override object GetValue()
        {
    /*        var o = base.GetValue();
            if (o != null)
            {
                return o;
            }
            return null;
        }*/
    }

}
