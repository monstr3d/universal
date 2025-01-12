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

        public Dictionary<string, OffSet> Inputs{ get; private set; } = new();

        public List<int[]> Indexes { get; private set; }

        public List<int[]> Index { get; private set; }

        public int[] Triangles 
        { 
            get; 
            private set; 
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<PolyList>();


        private PolyList(XmlElement element) : base(element)
        {
            var p = element.Get<P, int[]>();
            if (p != null)
            {
                Index = p.ToInt3Array();
                Triangles = p;
            }
              var c = element.GetAttribute("material");
            if (c == "acmat12")
            {

            }
           // Index = element.ToIntArray();
            Material = element.GetMaterial();
            if (Indexes == null)
            {
                Indexes = element.ToInt3Array();
            }
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