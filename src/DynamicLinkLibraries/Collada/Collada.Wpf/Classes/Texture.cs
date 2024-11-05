
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("texture")]
    public class Texture : XmlHolder
    {

 
        public Sampler2D Sample { get; private set; }

        public string TexCoord { get; private set; }
        public Texture(XmlElement xmlElement) : base(xmlElement)
        {
            var texture = xmlElement.GetAttribute("texture");
            Sample = Sampler2D.Get(texture);
            TexCoord = xmlElement.GetAttribute("texcoord");
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