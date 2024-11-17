using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class SimpleMaterial : Material
    {
        protected Color Color {  get; set; }

        protected SimpleMaterial(Color color)
        {
            Color = color;
        }
    }
}
