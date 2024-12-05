using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    partial class Collada14Converter
    {
        Tuple<object, List<AbstractMesh>> Create(Collada141.COLLADA collada)
        {
            var t = new Tuple<object, List<AbstractMesh>>(null, new List<AbstractMesh>());
   //         var sc = collada.asset.no
            return t;
        }

        AbstractMeshCollada Create(node node)
        {
            var mesh = CreareOwn(node);
            foreach (var item in node.node1)
            {
                var m = Create(item);
                m.Parent = mesh;
            }
            return mesh;
        }
    }
}
