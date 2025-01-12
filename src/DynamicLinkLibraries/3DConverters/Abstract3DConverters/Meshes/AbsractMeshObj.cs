using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Meshes
{
    internal class AbsractMeshObj : AbstractMesh
    {
        Obj3DCrearor Creator { get; set; }

   

        internal AbsractMeshObj(string name, Obj3DCrearor creator, string mat, List<int[][]> indexes) :
            base(name, creator, mat, null, null, null, null)
        {
            Creator = creator;
            Indexes = new();


            var vertices = creator.Vertices;
            if (vertices != null)
            {
                Vertices = new();
            }
            var textures = creator.Textures;
            if (textures != null)
            {
                Textures = new();
            }
            var normals = creator.Normals;
            if (normals != null)
            {
                Normals = new();
            }
            var i = 0;
            foreach (var item in indexes)
            {
                var ln = new List<int[]>();
                foreach (var idx in item)
                {
                    int[] indx = [-1, -1, -1];

                    var kp = idx[0];
                    if (kp >= 0)
                    {
                        indx[0] = i;
                        float[] v = vertices[kp];
                        Vertices.Add(v);
                    }
                    kp = idx[1];
                    if (kp >= 0)
                    {
                        indx[1] = i;
                        var v = textures[kp];
                        Textures.Add(v);
                    }
                    if (idx.Length > 2)
                    {
                        kp = idx[2];
                        if (kp >= 0)
                        {
                            indx[2] = i;
                            var v = normals[kp];
                            normals.Add(v);
                        }
                    }
                    ++i;
                    ln.Add(indx);
                }
                Indexes.Add(ln.ToArray());
            }
     //       Indexes.Add(ln.ToArray());

        }
    }
}