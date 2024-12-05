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
        Tuple<object, List<AbstractMesh>> Create()
        {
            var l = new List<AbstractMesh>();
            foreach (var node in Nodes)
            {
                l.Add(Create(node));
            }
            

            var t = new Tuple<object, List<AbstractMesh>>(null, l);
   //         var sc = collada.asset.no
            return t;
        }

        



        AbstractMeshCollada Create(node node)
        {
            var mesh = CreareOwn(node);
            if (node.node1 != null)
            {
                foreach (var item in node.node1)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    var m = Create(item);
                    m.Parent = mesh;
                }
            }
            return mesh;
        }
    }
}
