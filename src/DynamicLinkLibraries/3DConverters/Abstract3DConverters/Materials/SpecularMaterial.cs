namespace Abstract3DConverters.Materials
{
    /// <summary>
    /// Specular material
    /// </summary>
    public class SpecularMaterial : SimpleMaterial
    {
        #region Ctor

        /// <summary>
        /// Default constructor of zero material
        /// </summary>
        public SpecularMaterial() : this(new Color(), 0)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Color</param>
        /// <param name="power">Specular power</param>
        public SpecularMaterial(Color color, float power) : base(color)
        {
            SpecularPower = power;
        }

        #endregion

        public float SpecularPower { get; set; }


        protected override bool Equals(Material other)
        {
            if (other is SpecularMaterial specular)
            {
                if (Name != specular.Name)
                {
                    return false;
                }
                if (SpecularPower != specular.SpecularPower)
                {
                    return false;
                }
                if (Color != null)
                {
                    if (!Color.Equals(specular.Color))
                    {
                        return false;
                    }
                }
                else if (specular.Color != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }



        protected override object CloneIfself()
        {
            return new SpecularMaterial(Color.Clone() as Color, SpecularPower);
        }
    }
}
