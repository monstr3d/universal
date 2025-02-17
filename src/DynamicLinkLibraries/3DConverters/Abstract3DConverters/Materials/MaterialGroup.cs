namespace Abstract3DConverters.Materials
{
    public class MaterialGroup : Material
    {
        public List<Material> Children { get; } = new();


        public MaterialGroup(string name = null)
        {
            Name = name;
        }

   
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

        protected override bool Equals(Material other)
        {
            if (Name != other.Name)
            {
                return false;
            }
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


    }
}
