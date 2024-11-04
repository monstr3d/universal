using System.Collections.Generic;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class Surface : Sid, IImageSource
    {
        
        static public Surface Get(string s)
        {
            if (surfaces.ContainsKey(s))
            {
                return surfaces[s];
            }
            return null;
        }

        static Dictionary<string, Surface> surfaces = new();

        static public readonly string Tag = "surface";

        public ImageSource ImageSource { get; private set; }

        internal static void Clear()
        {
            surfaces.Clear();
        }


        public Surface(XmlElement element) : base(element)
        {

        }

        protected override void Process(XmlElement element)
        {
            ImageSource = element.InnerText.GetObject() as ImageSource;
        }

        public override void Set(NewParam newParam)
        {
            base.Set(newParam);
            var n = newParam.Name;
            if (surfaces.ContainsKey(n))
            {
                if (surfaces[n].Xml.InnerText != Xml.InnerText)
                {
                    throw new System.Exception();
                }
            }
            else
            {
                surfaces[n] = this;
            }
        }

        object GeSourcet(XmlElement element)
        {
            var s = Sid.Get(element);
            if (s != null)
            {
                return s;
            }
            return new Surface(element);
        }

        public static object Get(XmlElement element)
        {
   /*         var s = Sid.Get(element);
            if (s != null)
            {
                return s;
            }*/
            return new Surface(element);

        }

    }
}