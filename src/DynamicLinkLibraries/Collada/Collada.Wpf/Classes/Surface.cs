using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class Surface : Sid, IImageSource
    {

        static public readonly string Tag = "surface";

        public ImageSource ImageSource { get; private set; }


        public Surface(XmlElement element) : base(element)
        {

        }

        protected override void Process(XmlElement element)
        {
            ImageSource = element.InnerText.GetObject() as ImageSource;
        }

        object GetSurface(XmlElement element)
        {
            var s = Sid.Get(element);
            if (s != null)
            {
                return s;
            }
            return new Surface(element);
        }

    }
}