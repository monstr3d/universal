using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    partial class Collada14MeshCreator
    {
        public override Tuple<object, List<AbstractMesh>> Create()
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

        object ToZeroItem(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var pr = obj.GetType().GetProperty("Items");
            if (pr == null)
            {
                return null;
            }
            var it = pr.GetValue(obj);
            if (it == null)
            {
                return null;
            }
            if (it is Array array)
            {
                if (array.Length != 1)
                {
                    throw new Exception();
                }
                return array.GetValue(0);
            }
            return null;
        }

        T ToZeroItem<T>(object obj)
        {
            return (T) ToZeroItem(obj);
        }


        Image GetImage(object obj)
        {
            var image = obj as image;
            var im =  new Image(image.Item + "", directory);
            return im.Name == null ? null : im;
        }
        



        AbstractMesh Create(node node)
        {
            var mesh =  new AbstractMeshCollada(node, null, this);
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
