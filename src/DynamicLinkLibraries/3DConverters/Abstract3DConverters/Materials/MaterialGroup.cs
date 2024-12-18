using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
