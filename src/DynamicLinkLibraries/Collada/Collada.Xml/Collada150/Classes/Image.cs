
using System.Xml;
using Collada;

namespace Collada150.Classes
{
    [Tag("image", true)]
    internal class Image : XmlHolder
    {
        static public readonly string Tag = "image";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;

        public static IClear Clear => StaticExtensionCollada.GetClear<Image>();



        public ImageSource ImageSource { get; private set; }

        private Image(XmlElement element) : base(element)
        {
            ImageSource = element.InnerText.ToImage();
        }

        object Get()
        {
            if (ImageSource == null)
            {
                return this;
            }
            return ImageSource;
        }

        public static object Get(XmlElement element)
        {
            var a = new Image(element);
            return a.Get();
        }
    }
}