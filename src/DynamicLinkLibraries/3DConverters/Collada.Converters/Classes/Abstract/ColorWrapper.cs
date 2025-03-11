using System.Xml;
using Abstract3DConverters;
using Collada.Converters.Classes.Complicated;
using Collada.Converters.Classes.Elementary;
using ErrorHandler;

namespace Collada.Converters.Classes.Abstract
{
    internal class ColorWrapper : XmlHolder
    {
        internal Color Color { get; private set; }

        internal Sampler2D Sampler2D { get; private set; }

        internal Surface Surface { get; private set; }


        protected ColorWrapper(XmlElement element) : base(element, null)
        {
            try
            {
                var c = element.Get<ColorObject>();
                if (c != null)
                {
                    Color = c.Color;
                }
                var t = element.Get<Texture>();
                if (t != null)
                {
                    Sampler2D = t.Sampler2D;
                    Surface = t.Surface;
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("ColorWrapper");
            }
        }
    }
}
