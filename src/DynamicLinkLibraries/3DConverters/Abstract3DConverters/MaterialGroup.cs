using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class MaterialGroup : Material
    {

        public List<Material> Children { get; set; }
    }
}
