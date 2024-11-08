using System.Windows.Media.Media3D;
using System.Xml;
using System.Collections.Generic;

namespace Collada.Wpf.Classes
{
    [Tag("polylist")]
    internal class PolyList : XmlHolder
    {

        public Material Material { get; private set; }

        public Dictionary<string, object> Inputs{ get; private set; } = new();

        public List<int[]> Indexes { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<PolyList>();


        private PolyList(XmlElement element) : base(element)
        {
            Material = element.GetMaterial();
            Indexes = element.ToInt3Array();
            var d = element.GetAllChildren<Input>();
            foreach (var item in d)
            {
                var c = item.Semantic;
                Inputs[c.Key] = c.Value;
            }
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