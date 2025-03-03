using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Materials
{
    /// <summary>
    /// Group of materials
    /// </summary>
    public class MaterialGroup : Material, IImageHolder
    {
       

        /// <summary>
        /// Children
        /// </summary>
        public List<Material> Children { get; } = new();

        /// <summary>
        /// Attachement
        /// </summary>
        protected object Attachement { get;  set; }

        public MaterialGroup(object attachement)
        {
            Attachement = attachement;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        protected MaterialGroup(string name = null, object attachement = null)
        {
            Name = name;
            Attachement = attachement;
        }

        

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns></returns>
        protected override object CloneIfself()
        {
            var mat = new MaterialGroup(Name);
            var c = mat.Children;
            foreach (var child in Children)
            {
                if (child == null)
                {

                }
                c.Add(child.Clone() as Material);
            }
            return mat;
        }

        /// <summary>
        /// The equals operator
        /// </summary>
        /// <param name="other">Other material</param>
        /// <returns>True if equals</returns>
        protected override bool Equals(Material other)
        {
            if (other is MaterialGroup group)
            {
                var ch = group.Children;
                if (ch.Count != Children.Count)
                {
                    return false;
                }
                for (var i = 0; i < ch.Count; i++)
                {
                    if (!ch[i].Equals(Children[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual Image[] Images
        {
            get
            {
                var l = new List<Image>();
                foreach (var ch in Children)
                {
                    if (ch is IImageHolder ih)
                    {
                        l.AddRange(ih.Images);
                    }
                }
                return l.ToArray();

            }
        }

        #region IImageHolder Members

        Image[] IImageHolder.Images => Images;

        #endregion
    }
}
