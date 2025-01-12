
using System.Collections.Generic;
using System.Xml;
using System;
using System.Windows.Media;
namespace Collada.Wpf.Classes
{

    public abstract class Sid : Collada.XmlHolder, IImageSource
    {
        static Dictionary<XmlElement, Sid> dictionary = new();

        static List<string> xml = new();

        protected NewParam newParam;

        public NewParam NewParam => newParam;

        protected ImageSource imageSource;

        

        public ImageSource ImageSource => imageSource;

        public Sid(XmlElement element) : base(element)
        {
            var p = element.ParentNode as XmlElement;
            //     var sid = p.GetAttribute("sid");
            if (dictionary.ContainsKey(p))
            {
                throw new Exception();
            }
            dictionary[p] = this;
            Process(element);
        }

        protected virtual void Process(XmlElement element)
        {
            var inf = element.Get<Init_From>();
            if (inf != null)
            {
                imageSource = inf.ImageSource;
            }
        }

        public virtual void Set(NewParam newParam)
        {
            this.newParam = newParam;
        }

        public static Sid Get(XmlElement s)
        {
            if (dictionary.ContainsKey(s))
            {
                return dictionary[s];
            }
            throw new Exception();
        }
        /*
            public static Sid Get(XmlElement element)
            {
                //    var p = (element.ParentNode as XmlElement);
                /*     var sid = p.GetAttribute("sid");
                     if (dictionary.ContainsKey(sid))
                     {
                         if (xml.Contains(p.OuterXml))
                         {
                             return dictionary[sid];
                         }
                     }
                     return null;
                return null;
            }*/



        internal static void Clear()
        {
            dictionary.Clear();
            xml.Clear();
        }
    }
}

