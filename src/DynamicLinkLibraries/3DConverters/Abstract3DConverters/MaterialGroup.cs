using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class MaterialGroup : Material
    {
        public List<Material> Children { get; set; } = new();

        protected override object CloneIfself()
        {
            var mat = new MaterialGroup();
            var c = mat.Children;
            foreach ( var child in Children)
            {
                c.Add(child.Clone() as Material);
            }
            return mat;
        }
    }
}
