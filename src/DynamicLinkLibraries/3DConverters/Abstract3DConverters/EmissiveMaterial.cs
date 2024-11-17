using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class EmissiveMaterial : SimpleMaterial
    {
        public Image Image { get; private set; }

        public EmissiveMaterial(Color color, Image image) : base(color)
        {
            Image = image;
        }
    }
}