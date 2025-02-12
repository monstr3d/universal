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
            return new EmissiveMaterial(Color.Clone() as Color, null);
        }
   }
}