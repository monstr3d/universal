using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
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
        protected Effect(string name, Material material, Image image = null)
        {
            Name = name;
            Material = material;
            Image = image;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="effects">Effects</param>
        /// <param name="name">Name</param>
        /// <param name="material">Material</param>
        /// <param name="image">Image</param>
        public Effect(Dictionary<string, Effect> effects, string name, Material material, Image image = null) :
            this(name, material, image)
        {
            if (effects != null)
            {
                if (!effects.ContainsKey(name))
                {
                    effects[name] = this;
                }
            }
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
        /// Materials
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

        public Tuple<DiffuseMaterial, EmissiveMaterial, SpecularMaterial> NonzeroMaterials
        {
            get
            {
                var materials = Materials;
                var diff = materials.Item1;
                var emis = materials.Item2;
                var spec = materials.Item3;
                if (diff == null)
                {
                    diff = new DiffuseMaterial();
                }
                if (emis == null)
                {
                    emis = new EmissiveMaterial();
                }
                if (spec == null)
                {
                    spec = new SpecularMaterial();
                }

                return new Tuple<DiffuseMaterial, EmissiveMaterial, SpecularMaterial>(diff, emis, spec);
            }
        }
        public Tuple<DiffuseMaterial, EmissiveMaterial, SpecularMaterial> NonzeroColorMaterials
        {
            get
            {
                var materials = Materials;
                var diff = materials.Item1;
                var emis = materials.Item2;
                var spec = materials.Item3;
                if (diff == null)
                {
                    diff = new DiffuseMaterial(new Color(), new Color(), 0);
                }
                if (emis == null)
                {
                    emis = new EmissiveMaterial(new Color(), null);
                }
                if (spec == null)
                {
                    spec = new SpecularMaterial(new Color(), 0);
                }

                return new Tuple<DiffuseMaterial, EmissiveMaterial, SpecularMaterial>(diff, emis, spec);
            }
        }
    }
}
