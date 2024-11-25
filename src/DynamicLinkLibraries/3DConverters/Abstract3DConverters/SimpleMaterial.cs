using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public abstract class SimpleMaterial : Material
    {
        public Color Color {  get; private set; }

        protected SimpleMaterial(Color color)
        {
            Color = color.Clone() as Color;
        }
        
    }
}
