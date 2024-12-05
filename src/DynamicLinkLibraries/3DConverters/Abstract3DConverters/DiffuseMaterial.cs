
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

        public DiffuseMaterial(Color color, Color ambient, Image image = null, float opacity = 0) : base(color)
        {
            Image = image;
            Opacity = opacity;
            AmbientColor = ambient;
        }

        protected override object CloneIfself()
        {
            var im = (Image == null) ? null : Image.Clone() as Image;
            return new DiffuseMaterial(Color.Clone() as Color, AmbientColor.Clone() as Color,  im, Opacity);
        }
    }
}
