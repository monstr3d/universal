namespace Abstract3DConverters.Materials
{
    public class DiffuseMaterial : Material
    {

        #region Fields

        Image im;

        #endregion

        #region  Ctor

        public DiffuseMaterial(Color color, Color ambient,  float opacity)
        {
            Opacity = opacity;
            if (color == null)
            {

            }
            AmbientColor = ambient;
            Color = color;
        }

        #endregion



  

        public Color Color { get; private set; }


        public Color AmbientColor { get; private set; }

        public float Opacity 
        { 
            get; 
            private set; 
        }



        protected override object CloneIfself()
        {
            var color = Color == null ? null : Color.Clone() as Color;
            var ambient = AmbientColor == null ? null : AmbientColor.Clone() as Color;
            return new DiffuseMaterial(color, ambient, Opacity);
        }
    }
}
