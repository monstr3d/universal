

using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("texture")]
    public class Texture : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Texture>();

        internal Sampler2D Sampler2D { get; private set; }

        internal Surface Surface { get; private set; }

        public string TexCoord { get; private set; }

        internal Image Image { get; private set; }

        public Texture(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {
            bool succees = false;
            var texture = xmlElement.GetAttribute("texture");
            if (MeshCreator.Samples2D.ContainsKey(texture))
            {
                Sampler2D = MeshCreator.Samples2D[texture].Sampler2D;
                Surface = Sampler2D.Surface;
                succees = true;
            }
            if (MeshCreator.ImageIds.ContainsKey(texture))
            {
                Image = MeshCreator.ImageIds[texture];
                return;
            }
            if (!succees)
            {

                throw new Exception("Collada Texture");
            }
        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Texture(element, meshCreator);
            return a.Get();
        }
    }
}