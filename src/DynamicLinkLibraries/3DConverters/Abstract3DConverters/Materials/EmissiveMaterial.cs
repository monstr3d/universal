namespace Abstract3DConverters.Materials
{
    public class EmissiveMaterial : SimpleMaterial
    {
        public Image Image { get; private set; }

        public EmissiveMaterial(Color color, Image image = null) : base(color)
        {
            if (image != null)
            {
                Image = image.Clone() as Image;
            }
        }

        protected override object CloneIfself()
        {
            Color c = (this.Color == null) ? null : Color.Clone() as Color;
            return new EmissiveMaterial(c, null);
        }

        protected override bool Equals(Material other)
        {
            if (other is EmissiveMaterial emissive)
            {
                if (Name != emissive.Name)
                {
                    return false;
                }
                if (Color != null)
                {
                    if (!Color.Equals(emissive.Color))
                    {
                        return false;
                    }
                }
                else if (emissive.Color != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}