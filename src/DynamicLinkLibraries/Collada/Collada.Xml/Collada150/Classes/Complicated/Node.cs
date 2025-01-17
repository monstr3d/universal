
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;
using Collada;
using Collada150.Classes.Elementary;
using Collada150.Creators;

namespace Collada150.Classes.Complicated
{
    [Tag("node")]
    public class Node : Collada.XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Node>();

        Service s = new ();

        private Node(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            var creator = meshCreator as Collada15MeshCreator;
            var name = element.GetAttribute("name");
            var geom = element.GetFirstChild<InstanceGeomery>();
            var mat = element.GetFirstChild<BindMaterial>();
            var mt = element.GetFirstChild<Matrix>();
            float[] mm = null;
            if (mt != null)
            {
                mm = s.Convert(mt.Matrix3D);
            }
            var mesh = Create(geom, mat, name, mm);
            creator.Meshes[element] = mesh;
        }

        AbstractMesh Create(InstanceGeomery geom, BindMaterial material, string name, float[] mm)
        {
            Abstract3DConverters.Materials.Material mt = null;
            if (material != null)
            {
                mt = material.Material;
            }
            if (geom == null)
            {
                return new AbstractMesh(name, null);
            }
            List<float[]> vertices = null;
            List<float[]> normal = null;
            List<float[]> textures = null;
            List<int[][]> t = null;
            var g = geom.Geometry;
            var mesh = g.Mesh;
            if (mesh != null)
            {
                try
                {
                    var tr = mesh.Triangles;
                    int[] offs = new int[tr.Inputs.Count];
                    var h = new int[] { -1, -1, -1 };

                    if (tr.Inputs.ContainsKey("VERTEX"))
                    {
                        var o = tr.Inputs["VERTEX"];
                        offs[0] = o.Offset;
                        var v = o.Value as Vertices;
                        var x = v.Array;
                        vertices = s.ToRealArray(x, 3);
                        h[0] = o.Offset;
                    }
                    if (tr.Inputs.ContainsKey("TEXCOORD"))
                    {
                        var o = tr.Inputs["TEXCOORD"];

                        offs[1] = o.Offset;
                        var v = o.Value as float[];
                        textures = s.ToRealArray(v, 2);
                        h[1] = o.Offset;
                    }
                    if (tr.Inputs.ContainsKey("NORMAL"))
                    {
                        var o = tr.Inputs["NORMAL"];

                        offs[2] = o.Offset;
                        var v = o.Value as float[];
                        normal = s.ToRealArray(v, 3);
                        h[2] = o.Offset;
                    }
                    var ii = s.ToRealArray(tr.Idx, offs.Length, 3);
                    t = new List<int[][]>();
                    foreach (var p in ii)
                    {
                        int[][] k = new int[p.Length][];
                        for (int j = 0; j < p.Length; j++)
                        {
                            var pp = p[j];
                            var kj = new int[pp.Length];
                            k[j] = kj;
                            for (int hh = 0; hh < pp.Length; hh++)
                            {
                                kj[offs[hh]] = pp[hh];
                            }
                        }
                        t.Add(k);

                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError();
                }
            }
            try
            {
                return new AbstractMesh(name, null, mt, vertices, normal, textures, t, mm);
            }
            catch (Exception e)
            {
                e.ShowError();
            }
            return null;
        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return  new Node(element, meshCreator);
        }

    }
}