using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class Polygon
    {
        public List<Tuple<int, float[]>> Points {  get; private set; }

        public Polygon(List<Tuple<int, float[]>> points)
        {
            Points = points;
        }
    }
}
