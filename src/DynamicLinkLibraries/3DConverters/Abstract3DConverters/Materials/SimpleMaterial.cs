
namespace Abstract3DConverters.Materials
{
    public abstract class SimpleMaterial : Material
    {
        public Color Color { get; private set; }

        protected SimpleMaterial(Color color)
        {
            if (color != null)
            {
                Color = color.Clone() as Color;
            }
        }

    }
}
