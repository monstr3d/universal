using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Image : XmlHolder
    {
        static public readonly string Tag = "image";

        public ImageSource ImageSource { get; private set; }

        private Image(XmlElement element) : base(element)
        {
            ImageSource = element.InnerText.ToImage();
        }

        object Get()
        {
            if (ImageSource == null)
            {
                return false;
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