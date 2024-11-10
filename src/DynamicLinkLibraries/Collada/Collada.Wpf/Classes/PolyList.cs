using System.Windows.Media.Media3D;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace Collada.Wpf.Classes
{
    [Tag("polylist")]
    internal class PolyList : XmlHolder
    {

        public Material Material { get; private set; }

        public Dictionary<string, object> Inputs{ get; private set; } = new();

        public List<int[]> Indexes { get; private set; }

        public int[] Index { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<PolyList>();


        private PolyList(XmlElement element) : base(element)
        {
            var c = element.GetAttribute("material");
            if (c == "acmat12")
            {

            }
            Index = element.ToIntArray();
            Material = element.GetMaterial();
            Indexes = element.ToInt3Array();
            //Indexes = element.ToTextureArray();
            var d = element.GetAllChildren<Input>().ToArray();
            foreach (var inp in d)
            {
                var sem = inp.Semantic;
                Inputs[sem.Key] = sem.Value;
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