using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Collada;
using Collada150.Classes.Elementary;

namespace Collada150.Classes.Complicated
{
    [Tag("triangles")]
    internal class Triangles : XmlHolder
    {

        Service s = new Service();
        public Material Material { get; private set; }

        public Dictionary<string, OffSet> Inputs { get; private set; } = new();

        public int[] Idx { get; private set; }

    //    public List<int[]> Indexes { get; private set; }

        public List<int[]> Index { get; private set; }

        public int[] P { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Triangles>();

        public Tuple<List<float[]>, List<float[]>, List<float[]>, List<int[]>> Tuple { get; private set; }
        



      

        private Triangles(XmlElement element) : base(element, null)
        {
            var p = element.Get<P>();
            if (p != null)
            {
                Idx = p.Value;
            }
         //   // Index = element.ToIntArray();
     /*       Material = element.GetMaterial();
   /        if (Indexes == null)
            {
                Indexes = element.ToInt3Array();
            }*/
            var d = element.GetAllChildren<Input>().ToArray();
            foreach (var inp in d)
            {
                var sem = inp.Semantic;
                Inputs[sem.Key] = sem.Value;
            }
            List<float[]> vertices = null;
            
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Triangles(element);
            return a.Get();
        }
    }
}
