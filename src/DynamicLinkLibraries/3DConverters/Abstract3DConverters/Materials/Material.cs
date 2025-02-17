namespace Abstract3DConverters.Materials
{
    public abstract class Material : ICloneable, IEquatable<Material>
    {
        public Color Color { get; set; }

        public string Name { get; protected set; } = null;


        public object Clone()
        {
            return CloneIfself();
        }

        protected abstract object CloneIfself();


        protected abstract bool Equals(Material other);

        bool IEquatable<Material>.Equals(Material? other)
        {
            if (other == null)
            {
                return false;
            }
            return Equals(other);
        }
    }
}