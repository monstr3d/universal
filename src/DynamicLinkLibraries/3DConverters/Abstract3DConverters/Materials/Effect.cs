using System.Reflection;
using Abstract3DConverters.Interfaces;

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
        protected  Effect(string name, Material material, Image image = null)
        {
            Name = name;
            Material = material;
            Image = image;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">Creator of meshes</param>
        /// <param name="name">Name</param>
        /// <param name="material">Material</param>
        /// <param name="image">Image</param>
        public Effect(IMeshCreator creator, string name, Material material, Image image = null) : 
            this(name, material, image)
        {
            if (creator == null)
            {
                return;
            }
            var eff = creator.Effects;
            if (!eff.ContainsKey(name))
            {
                eff[name] = this;
            }
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

        /// <summary>
        /// Materias
        /// </summary>
        public Tuple<DiffuseMaterial, EmissiveMaterial, SpecularMaterial> Materials
        {
            get
            {
                DiffuseMaterial d = null;
                EmissiveMaterial e = null;
                SpecularMaterial s = null;
                var m = Material as MaterialGroup;
                foreach (var material in m.Children)
                {
                    switch (material)
                    {
                        case DiffuseMaterial dm:
                            d = dm;
                            break;
                        case EmissiveMaterial em:
                            e = em;
                            break;
                        case SpecularMaterial sm:
                            s = sm;
                            break;
                    }
                }
                return new Tuple<DiffuseMaterial, EmissiveMaterial, SpecularMaterial>(d, e, s);

            }
        }
    }
}
