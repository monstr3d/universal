
using System.Net.Http.Headers;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes
{
    [Tag("image", true)]
    internal class Image : XmlHolder
    {
        static public readonly string Tag = "image";

        Service s = new Service();

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;

        public static IClear Clear => StaticExtensionCollada.GetClear<Image>();



        public Abstract3DConverters.Image ImageSource { get; private set; }

        private Image(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            ImageSource = new Abstract3DConverters.Image(element.InnerText, meshCreator.Directory);
        }

        object Get()
        {
            if (ImageSource == null)
            {
                return this;
            }
            return ImageSource;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Image(element, meshCreator);
            return a.Get();
        }
    }
}