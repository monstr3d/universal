

using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Complicated
{
    [Tag("texture")]
    public class Texture : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Texture>();

        internal Sampler2D Sampler2D { get; private set; }

        internal Surface Surface { get; private set; }

        public string TexCoord { get; private set; }
        public Texture(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {
            var texture = xmlElement.GetAttribute("texture");
            if (MeshCreator.Samples2D.ContainsKey(texture))
            {
                Sampler2D = MeshCreator.Samples2D[texture].Sampler2D;
                Surface = Sampler2D.Surface;
                return;
            }
            throw new Exception();
        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Texture(element, meshCreator);
            return a.Get();
        }
    }
}