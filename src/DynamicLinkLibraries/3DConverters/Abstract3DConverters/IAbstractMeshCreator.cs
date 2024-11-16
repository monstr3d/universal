using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public interface IAbstractMeshCreator
    {
        string Extension { get; }

        List<AbstractMesh> Create(string filename);
    }
}
