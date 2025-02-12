using System.Reflection;

namespace Abstract3DConverters.Materials
{
    /// <summary>
    /// Effect
    /// </summary>
    public class Effect : ICloneable
    {
        /// <summary>
        /// Material
        /// </summary>
        public Material Material
        {
            get;
            protected set;
        }

        /// <summary>
        /// Image
        /// </summary>
        public Image Image
        {
            get;
            protected set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            protected set;
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="material">Material</param>
        /// <param name="image">Image</param>
        public Effect(string name, Material material, Image image = null)
        {
            Name = name;
            Material = material;
            Image = image;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>The clone</returns>
        public virtual object Clone()
        {
            var mat = Material.Clone() as Material;
            if (Image == null)
            {
                return new Effect(Name, mat);
            }
            return new Effect(Name, mat, Image.Clone() as Image);
        }
    }
}
