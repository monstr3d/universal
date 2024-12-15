using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collada141;

namespace Collada.Converter
{
    partial class Collada14MeshCreator
    {
        IEnumerable<node> Nodes
        {
            get
            {
                var it = collada.Items;
                foreach (var i in it)
                {
                    if (i is library_visual_scenes sc)
                    {
                        var vs = sc.visual_scene;
                        foreach (var v in vs)
                        {
                            var nd = v.node;
                            foreach (var n in nd)
                            {
                                yield return n;
                            }
                        }
                    }
                }
                yield break;
            }
        }
    }
}