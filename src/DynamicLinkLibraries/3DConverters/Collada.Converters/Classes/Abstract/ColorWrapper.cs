using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

using Collada.Converters.Classes.Complicated;
using Collada.Converters.Classes.Elementary;



namespace Collada.Converters.Classes.Abstract
{
    internal class ColorWrapper : XmlHolder, IColored
    {
        internal Color Color { get; private set; }

        internal Sampler2D Sampler2D { get; private set; }

        internal Surface Surface { get; private set; }

        Color IColored.Color => Color;

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
