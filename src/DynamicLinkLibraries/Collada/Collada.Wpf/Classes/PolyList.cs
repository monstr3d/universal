using System.Windows.Media.Media3D;
using System.Xml;
using System.Collections.Generic;

namespace Collada.Wpf.Classes
{
    [Tag("polylist")]
    internal class PolyList : XmlHolder
    {

        public Material Material { get; private set; }

        public Input Input {  get; private set; }

        public List<int[]> Indexes { get; private set; }

        private PolyList(XmlElement element) : base(element)
        {
            Material = element.GetMaterial();
            Indexes = element.ToInt3Array();
            Input = element.Get<Input>();
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new PolyList(element);
            return a.Get();
        }
    }
}