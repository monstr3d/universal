using Abstract3DConverters.Meshes;
using Abstract3DConverters.Points;
using Collada.Converters.Classes.Complicated;
using Collada.Converters.MeshCreators;

namespace Collada.Converters.Meshes
{
    
    class AbstractMeshCollada : AbstractMeshPolygon
    {

        private ColladaMeshCreator meshCreator;

        float[] GetValue(object o)
        {
            switch (o)
            {
                case Source so:
                    return so.Array;
                case Vertices v:
                    return v.Array;
            }
            throw new Exception();
        }


        internal AbstractMeshCollada(InstanceGeomery geom, BindMaterial material, string name, float[] mm, ColladaMeshCreator creator) : base(name, null, mm, creator)
        {
            if (geom == null)
            {
                return;
            }
            meshCreator = creator;
            Effect = material.Effect;
            var g = geom.Geometry;
            var meshObject = g.Mesh;
            var tr = meshObject.Triangles;
            List<float[]> vertices = null;
            List<float[]> normal = null;
            List<float[]> textures = null;
            List<int[][]> t = null;
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
                return;
            }
            var poly = meshObject.Polygon;
            if (poly == null)
            {
                return;
            }
            var vv = poly.Vertices;
            if (vv == null)
            {
                return;
            }
            if (vv.Length == 0)
            {
                return;
            }
            Points = new();
            if (poly.Vertices.Length > 0)
            {
                Points = new();
                vertices = s.ToRealArray(poly.Vertices, 3);
                if (poly.Normals != null)
                {
                    normal = s.ToRealArray(poly.Normals, 2);
                    if (normal.Count > 0)
                    {
                        for (int i = 0; i < vertices.Count; i++)
                        {
                            var p = new Abstract3DConverters.Points.Point(vertices[i], normal[i]);
                            Points.Add(p);
                        }
                        goto label;
                    }
                }
                for (int j = 0; j < vertices.Count; j++)
                {
                    var p = new Abstract3DConverters.Points.Point(vertices[j]);
                    Points.Add(p);
                }

            }
        label:
            Polygons = new();
            foreach (var p in poly.Polygons)
            {
                var pp = new Polygon(p.Points, Effect);
                Polygons.Add(p);
            }
   
        }
    }
}
