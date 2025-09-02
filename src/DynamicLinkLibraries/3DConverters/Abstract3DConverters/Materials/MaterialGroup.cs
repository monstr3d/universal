using Abstract3DConverters.Interfaces;
using NamedTree;

namespace Abstract3DConverters.Materials
{
    /// <summary>
    /// Group of materials
    /// </summary>
    public class MaterialGroup : Material, IChildren<SimpleMaterial>, IImageHolder
    {
       

        /// <summary>
        /// Children
        /// </summary>
        protected virtual List<SimpleMaterial> Children { get; } = new();

        /// <summary>
        /// Attachement
        /// </summary>
        public object Attachement { get; protected set; }

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

        event Action<SimpleMaterial> IChildren<SimpleMaterial>.OnAdd
        {
            add
            {
             }

            remove
            {
            }
        }

        event Action<SimpleMaterial> IChildren<SimpleMaterial>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }



        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns></returns>
        protected override object CloneIfself()
        {
            IChildren<SimpleMaterial> mat = new MaterialGroup(Name);
       
            var c = mat.Children;
            foreach (var child in Children)
            {
                if (child == null)
                {

                }
                mat.AddChild(child.Clone() as SimpleMaterial);
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

        void IChildren<SimpleMaterial>.AddChild(SimpleMaterial child)
        {
            Children.Add(child);
        }

        void IChildren<SimpleMaterial>.RemoveChild(SimpleMaterial child)
        {

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

        IEnumerable<SimpleMaterial> IChildren<SimpleMaterial>.Children => Children;

        #endregion
    }
}
