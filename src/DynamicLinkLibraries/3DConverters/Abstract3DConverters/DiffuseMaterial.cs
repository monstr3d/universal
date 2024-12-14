
namespace Abstract3DConverters
{
    public class DiffuseMaterial : Material
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


        public Color Color { get; private set; }


        public Color AmbientColor { get; private set; }

        public float Opacity { get; private set; }

        public DiffuseMaterial(Color color, Color ambient, Image image, float opacity = 1) 
        {
            Image = image;
            Opacity = opacity;
            AmbientColor = ambient;
            Color = color;
        }

        protected override object CloneIfself()
        {
            var im = (Image == null) ? null : Image.Clone() as Image;
            var color = (Color == null) ? null : Color.Clone() as Color;
            var ambient = (AmbientColor == null) ? null : AmbientColor.Clone()  as Color;
            return new DiffuseMaterial(color, ambient,  im, Opacity);
        }
    }
}
