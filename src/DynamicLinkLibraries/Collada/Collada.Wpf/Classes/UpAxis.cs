using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Up_Axis : XmlHolder
    {
        static public readonly string Tag = "up_axis";

        private Up_Axis(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Up_Axis(element);
            return a.Get();
        }
    }
}