using System;
namespace Abstract3DConverters
{
    public  abstract class Material : ICloneable
    {
        public Color  Color { get; set; }

        public object Clone()
        {
            return CloneIfself();
        }

        protected abstract object CloneIfself();
    }
}
