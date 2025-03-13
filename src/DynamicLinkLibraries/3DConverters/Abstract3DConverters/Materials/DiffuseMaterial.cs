using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Materials
{
    /// <summary>
    /// Diffuse material
    /// </summary>
    public class DiffuseMaterial : Material, IImageHolder
    {

        #region Fields

        protected Image Image
        {
            get;
            private set;
        }

        #endregion

        #region  Ctor

        /// <summary>
        /// Default constructor of zero material
        /// </summary>
        public  DiffuseMaterial() : this(new Color(), null, 0)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Color</param>
        /// <param name="ambient">Ambient color</param>
        /// <param name="opacity">Opacity</param>
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

        Image[] IImageHolder.Images => Image == null ? null : [Image];

        #region Overriden

        protected override bool Equals(Material other)
        {
            if (other is DiffuseMaterial diffuse)
            {
                if (Name != diffuse.Name)
                {
                    return false;
                }
                if (Opacity != diffuse.Opacity)
                {
                    return false;
                }
                if (Color != null)
                {
                    if (!Color.Equals(diffuse.Color))
                    {
                        return false;
                    }
                }
                else if (diffuse.Color != null)
                {
                    return false;
                }
                if (AmbientColor != null)
                {
                    if (!AmbientColor.Equals(AmbientColor))
                    {
                        return false;
                    }
                }
                else if (diffuse.AmbientColor != null)
                {
                    return false;
                }
                return true;

            }
            return false;
        }

        protected override object CloneIfself()
        {
            var color = Color == null ? null : Color.Clone() as Color;
            var ambient = AmbientColor == null ? null : AmbientColor.Clone() as Color;
            return new DiffuseMaterial(color, ambient, Opacity);
        }

        #endregion
    }
}
