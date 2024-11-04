
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class Texture : XmlHolder, IImageSource
    {

        static public readonly string Tag = "texture";

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

        public Texture(XmlElement xmlElement) : base(xmlElement)
        {
            var texture = xmlElement.GetAttribute("texture");
            Sid = Sid.Get(texture);
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Texture(element);
            return a.Get();

        }
    }
}