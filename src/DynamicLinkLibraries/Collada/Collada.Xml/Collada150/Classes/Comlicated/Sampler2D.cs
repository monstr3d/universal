
using System.Xml;
using Collada;
namespace Collada150.Classes.Comlicated
{

    [Tag("sampler2D")]
    public class Sampler2D : Sid
    {
        static public readonly string Tag = "sampler2D";

        static Dictionary<string, Sampler2D> samplers = new();


        public static IClear Clear => StaticExtensionCollada.GetClear<Sampler2D>();



        static public Sampler2D Get(string s)
        {
            if (samplers.ContainsKey(s))
            {
                return samplers[s];
            }
            return null;
        }

        internal static void ClearT()
        {
            samplers.Clear();
        }



        public Surface Surface { get; private set; }


        public Sampler2D(XmlElement element) : base(element)
        {
            var sur = element.Get<Surface>();
            if (sur != null)
            {
                Surface = sur;
            }
            if (ImageSource != null)
            {
                return;
            }
            var s = element.Get<Source>();
            if (s != null)
            {
                var ss = s.Xml.InnerText;
                Surface = Surface.Get(ss);
                if (Surface != null)
                {
                    imageSource = Surface.ImageSource;
                }
            }

        }

        public override void Set(NewParam newParam)
        {
            base.Set(newParam);
            var n = newParam.Name;
            if (samplers.ContainsKey(newParam.Name))
            {
                if (samplers[n].Xml.OuterXml != Xml.OuterXml)
                {
                    throw new Exception();
                }
            }
            else
            {
                samplers[n] = this;
                n = n.Replace("Sampler", "Surface");
                Surface = Surface.Get(n);
            }
        }


        public static object Get(XmlElement element)
        {
            /*      var s = Sid.Get(element);
                  if (s != null)
                  {
                      return s;
                  }*/
            return new Sampler2D(element);

        }

    }
}