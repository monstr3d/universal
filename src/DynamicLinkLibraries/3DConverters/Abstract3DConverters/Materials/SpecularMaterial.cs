namespace Abstract3DConverters.Materials
{
    public class SpecularMaterial : SimpleMaterial
    {
        public float SpecularPower { get;  set; }


        public SpecularMaterial(Color color, float power) : base(color)
        {
            SpecularPower = power;
        }

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
