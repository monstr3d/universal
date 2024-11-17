using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class DiffuseMaterial : SimpleMaterial
    {
        public Image Image {  get; private set; }

        public Color AmbientColor { get; private set; }

        public float Opacity { get; private set; }

        public DiffuseMaterial(Color color, Image image, float opacity) : base(color)
        {
            Image = image;
            Opacity = opacity;
        }
    }
}
