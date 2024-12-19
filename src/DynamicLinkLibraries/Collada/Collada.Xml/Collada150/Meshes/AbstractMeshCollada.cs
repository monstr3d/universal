using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

namespace Collada150.Meshes
{
    internal class AbstractMeshCollada : AbstractMeshPolygon
    {
        public AbstractMeshCollada(string name, AbstractMeshPolygon parent, IMeshCreator creator) : base(name, parent, creator)
        {
        }

        public override void Disintegrate()
        {
            throw new NotImplementedException();
        }
    }
}
