using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;
using Abstract3DConverters.Materials;
using Collada;

namespace Collada150.Classes
{
    [Tag("triangles")]
    internal class Triangles : XmlHolder
    {

        public Material Material { get; private set; }

        public Dictionary<string, OffSet> Inputs { get; private set; } = new();

        public List<int[]> Indexes { get; private set; }

        public List<int[]> Index { get; private set; }

        public int[] Polygon
        {
            get;
            private set;
        }


        private Triangles(XmlElement element) : base(element)
        {
            var p = element.Get<P, int[]>();
            if (p != null)
            {
                Index = p.ToInt3Array();
                Polygon = p;
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
            var a = new Triangles(element);
            return a.Get();
        }
    }
}
