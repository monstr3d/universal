using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class Polygon
    {
        public List<Tuple<int, int, float[]>> Points {  get; private set; }

        public Polygon(List<Tuple<int, int, float[]>> points)
        {
            foreach (var p in points)
            {
                if (p.Item1 < 0)
                {

                }
            }
            Points = points;
        }
    }
}
