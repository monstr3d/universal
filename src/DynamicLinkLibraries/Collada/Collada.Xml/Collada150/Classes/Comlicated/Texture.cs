

using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("texture")]
    public class Texture : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Texture>();

        internal Abstract3DConverters.Image Image { get; private set; }

        public string TexCoord { get; private set; }
        public Texture(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {
            var texture = xmlElement.GetAttribute("texture");
            if (meshCreator.Images.ContainsKey(texture))
            {
                Image = meshCreator.Images[texture];
            }
            else
            {

            }
     
        }

 

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Texture(element, meshCreator);
            return a.Get();

        }
    }
}