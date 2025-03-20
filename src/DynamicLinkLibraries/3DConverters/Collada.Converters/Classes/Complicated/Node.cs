
using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

using Collada.Converters.Classes.Elementary;
using Collada.Converters.MeshCreators;
using Collada.Converters.Meshes;



namespace Collada.Converters.Classes.Complicated
{
    [Tag("node")]
    public class Node : Collada.XmlHolder
    {
        MeshObject meshObject;

        public static IClear Clear => StaticExtensionCollada.GetClear<Node>();

        ColladaMeshCreator Creator
        {
            get;
            set;
        }


        Service s = new ();

        private Node(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            Creator = meshCreator as ColladaMeshCreator;
            var name = element.GetAttribute("name");
            var geom = element.GetFirstChild<InstanceGeomery>();
            BindMaterial mat = null;
            if (geom != null)
            {
                mat = geom.Xml.GetFirstChild<BindMaterial>();
            }
            var mt = element.GetFirstChild<Matrix>();
            float[] mm = null;
            if (mt != null)
            {
                mm = s.Convert(mt.Matrix3D);
            }
            if (mat == null)
            {

            }
            var mesh = Create(geom, mat, name, mm);
            if (mesh == null)
            {
                throw new Exception("MESH_NULL");
            }
            Creator.MeshesParent[element] = mesh;
        }


        float[] GetValue(object o)
        {
            switch (o)
            {
                case Source so:
                    return so.Array;
                case Vertices v:
                    return v.Array;
            }
            throw new Exception("Node GetValue");
        }

        AbstractMesh Create(InstanceGeomery geom, BindMaterial material, string name, float[] mm)
        {
            return new AbstractMeshCollada(geom, material, name, mm, Creator);
            Abstract3DConverters.Materials.Effect effect = material.Effect;

            if (geom == null)
            {
                return new AbstractMesh(name, Creator);
            }
            List<float[]> vertices = null;
            List<float[]> normal = null;
            List<float[]> textures = null;
            List<int[][]> t = null;
            var g = geom.Geometry;
            meshObject = g.Mesh;
            var tr = meshObject.Triangles[0];
            if (tr != null)
            {
                int[] offs = new int[tr.Inputs.Count];
                var h = new int[] { 0, 0, 0 };

                if (tr.Inputs.ContainsKey("VERTEX"))
                {
                    var o = tr.Inputs["VERTEX"];
                    offs[0] = o.Offset;
                    var x = GetValue(o.Value);
                    if (x != null)
                    {
                        vertices = s.ToRealArray(x, 3);
                    }
                    else
                    {
                        vertices = null;
                    }
                    h[0] = o.Offset;
                }
                if (tr.Inputs.ContainsKey("TEXCOORD"))
                {
                    var o = tr.Inputs["TEXCOORD"];
                    offs[1] = o.Offset;
                    var v = GetValue(o.Value);
                    if (v != null)
                    {
                        textures = s.ToRealArray(v, 2);
                    }
                    else
                    {
                        textures = null;
                    }
                    h[1] = o.Offset;
                }
                if (tr.Inputs.ContainsKey("NORMAL"))
                {
                    var o = tr.Inputs["NORMAL"];
                    offs[2] = o.Offset;
                    var v = GetValue(o.Value);
                    if (v != null)
                    {
                        normal = s.ToRealArray(v, 3);
                    }
                    else
                    {
                        normal = null;
                    }
                    h[2] = o.Offset;
                }
                if (tr.Idx != null)
                {
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

                return new AbstractMesh(name, Creator, effect, vertices, normal, textures, t, mm);
            }


            try
            {

                var poly = meshObject.PolyList;
                if (poly == null)
                {
                    return new AbstractMesh(name, Creator);
                }
                List<float[]> vv = null;
                if (poly.Vertices != null)
                {
                    vv = s.ToRealArray<float>(poly.Vertices, 3);
                }
                if (vv == null)
                {
                    return new AbstractMesh(name, Creator);
                }
                return null;// new AbstractMeshPolygon(name, null, mm, mt, poly.Polygons, vv, null, Creator);
            }
            catch (Exception e)
            {
                e.HandleException("Node polygon");
            }
            return null;

        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return  new Node(element, meshCreator);
        }

    }
}