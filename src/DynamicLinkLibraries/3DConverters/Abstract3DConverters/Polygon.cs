using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters
{
    public class Polygon
    {
        public List<Tuple<int, int, int, float[]>> Points {  get; private set; }

        public Material Material { get; private set; }

        public Polygon(List<Tuple<int, int, int, float[]>> points, Material material)
        {
            if (material == null)
            {

            }
            foreach (var p in points)
            {
                if (p.Item1 < 0)
                {

                }
            }
            Material = material;
            Points = points;
        }

        public string MaterialName => Material.Name;
    }
}
