using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("instance_visual_scene")]
    internal class InstanceVisualScene : XmlHolder
    {
        static public readonly string Tag = "instance_visual_scene";

        private InstanceVisualScene(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new InstanceVisualScene(element);
            return a.Get();
        }
    }
}