using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class AbstractMeshAC : AbstractMesh
    {

        int count;

        List<string> l;

        public AbstractMeshAC(string name, int count, List<string> l) : base(name)
        {
            this.count = count;
            this.l = l;
        }
    }
}
