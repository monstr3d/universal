using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class DiffuseMaterial : SimpleMaterial
    {
        public Image Image {  get; internal set; }

        public Color AmbientColor { get; private set; }

        public float Opacity { get; private set; }

        public DiffuseMaterial(Color color, Image image = null, float opacity = 0) : base(color)
        {
            Image = image;
            Opacity = opacity;
        }

        protected override object CloneIfself()
        {
            return new DiffuseMaterial(Color.Clone() as Color, null, Opacity);
        }
    }
}
