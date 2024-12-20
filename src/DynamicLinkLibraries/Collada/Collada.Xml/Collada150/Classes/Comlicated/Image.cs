
using System.Net.Http.Headers;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("image")]
    internal class Image : XmlHolder
    {
        static public readonly string Tag = "image";

        Service s = new Service();

     
        public static IClear Clear => StaticExtensionCollada.GetClear<Image>();



        public Abstract3DConverters.Image ImageSource { get; private set; }

        private Image(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var ifr = element.Get<Init_From>().Text;
            ImageSource = new Abstract3DConverters.Image(ifr, meshCreator.Directory);
            meshCreator.Images[ImageSource.Name] = ImageSource;
            MeshCreator.ImageIds[element.GetAttribute("id")] = ImageSource;
        }

   

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Image(element, meshCreator);
            return a.Get();
        }
    }
}