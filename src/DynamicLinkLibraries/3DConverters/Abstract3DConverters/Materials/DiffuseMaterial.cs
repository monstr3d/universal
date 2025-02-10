namespace Abstract3DConverters.Materials
{
    public class DiffuseMaterial : Material
    {

        #region Fields

        Image im;

        #endregion

        #region  Ctor

        public DiffuseMaterial(Color color, Color ambient, Image image, float opacity)
        {
            Image = image;
            Opacity = opacity;
            if (color == null)
            {

            }
            AmbientColor = ambient;
            Color = color;
        }

        #endregion


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

        public float Opacity 
        { 
            get; 
            private set; 
        }


        public override bool HasImage => Image != null;

        protected override object CloneIfself()
        {
            var im = Image == null ? null : Image.Clone() as Image;
            var color = Color == null ? null : Color.Clone() as Color;
            var ambient = AmbientColor == null ? null : AmbientColor.Clone() as Color;
            return new DiffuseMaterial(color, ambient, im, Opacity);
        }
    }
}
