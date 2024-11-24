using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class SpecularMaterial : SimpleMaterial
    {
        public float SpecularPower { get; private set; }

        public SpecularMaterial(Color color,  float power) : base(color)
        {
            SpecularPower = power;
        }

        protected override object CloneIfself()
        {
            return new SpecularMaterial(Color.Clone() as  Color, SpecularPower);
        }
    }
}
