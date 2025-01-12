using System.Collections.Generic;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("surface")]
    public class Surface : Sid
    {
        static Surface()
        {
            surfaces = new();
            sids = new(); ;

        }

        static public Surface Get(string s)
        {
            if (surfaces.ContainsKey(s))
            {
                return surfaces[s];
            }
            return GetSid(s);
        }

        static Dictionary<string, Surface> surfaces = null;

        static Dictionary<string, Surface> sids = null;


        static public readonly string Tag = "surface";


        new internal static void Clear()
        {
            surfaces.Clear();
            sids.Clear();
        }


        public Surface(XmlElement element) : base(element)
        {
            var p = element.ParentNode;
            if (p.Name == "newparam")
            {
                XmlElement a = p as XmlElement;
                var sid = a.GetAttribute("sid");
                if (sid.Length > 0)
                {
                    sids[sid] = this;
                }

            }
        }

        public static Surface GetSid(string sid)
        {
            if (sids.ContainsKey(sid))
            {
                return sids[sid];
            }
            return null;
        }

        protected override void Process(XmlElement element)
        {
            base.Process(element);
            if (imageSource != null)
            {
                return;
            }
  
            ImageSource iso = element.InnerText.GetObject() as ImageSource;
            if (iso != null)
            {
                imageSource = iso;
                return;
            }
        }


        public override void Set(NewParam newParam)
        {
            base.Set(newParam);
            var n = newParam.Name;
            var sf = Surface.Get(n);
            if (sf != null)
            {
                if (imageSource == null)
                {
                    imageSource = sf.ImageSource;
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

        public new static object Get(XmlElement element)
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