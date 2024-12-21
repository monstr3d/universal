using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

namespace Collada150.Meshes
{
    internal class AbstractMeshCollada : AbstractMesh
    {
        public AbstractMeshCollada(string name,  IMeshCreator creator) : base(name, creator)
        {
        }

 

    }
}
