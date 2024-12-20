using System.Xml;
using Collada;

namespace Collada150.Classes.Comlicated
{
    internal class VisualScene : XmlHolder
    {
        static public readonly string Tag = "visual_scene";

        private VisualScene(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new VisualScene(element);
            return a.Get();
        }
    }
}