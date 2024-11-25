using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class DiffuseMaterial : SimpleMaterial
    {

        Image im;

        public Image Image 
        {  
            get => im; 
            internal set
            {
                if (value == null)
                {
                    if (im != null)
                    {
                        throw new Exception();
                    }
                }
                im = value;
            }
        }

        public Color AmbientColor { get; private set; }

        public float Opacity { get; private set; }

        public DiffuseMaterial(Color color, Image image = null, float opacity = 0) : base(color)
        {
            Image = image;
            Opacity = opacity;
        }

        protected override object CloneIfself()
        {
            var im = (Image == null) ? null : Image.Clone() as Image;
            return new DiffuseMaterial(Color.Clone() as Color, im, Opacity);
        }
    }
}
