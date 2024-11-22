using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class AbstractMeshListString : AbstractMesh
    {
        protected List<string> strings;
        public AbstractMeshListString(string name, List<string> strings) : base(name)
        {
            this.strings = strings;
        }
    }
}
