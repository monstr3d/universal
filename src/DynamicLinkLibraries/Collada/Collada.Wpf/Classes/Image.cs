using System.Text.Json.Serialization;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("image", true)]
    internal class Image : XmlHolder
    {
        static public readonly string Tag = "image";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;



        public ImageSource ImageSource { get; private set; }

        private Image(XmlElement element) : base(element)
        {
            ImageSource = element.InnerText.ToImage();
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Image(element);
            return a.Get();
        }
    }
}