using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;
using Collada.Converters.Classes.Complicated;
using Collada.Converters.MeshCreators;
using ErrorHandler;

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
            throw new Exception("Collade GetValue");
        }


        internal AbstractMeshCollada(InstanceGeomery geom, BindMaterial material, string name, float[] mm, ColladaMeshCreator creator) : base(name, null, mm, creator)
        {
            try
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
                var poly = meshObject.Polygon as IMesh;
                Vertices = poly.Vertices;
                Textures = poly.Textures;
                Normals = poly.Normals;
                Polygons = poly.Polygons;
                return;
            }
            catch (Exception e)
            {
                e.ShowError("AbstractMeshCollada constructor");
                throw new IncludedException(e, "AbstractMeshCollada constructor");
            }
            
       /*      Points = new();
            if (poly.Vertices.Length > 0)
            {
                Points = new();
                vertices = s.ToRealArray(poly.Vertices, 3);
                if (poly.Normals != null)
                {
                    normal = s.ToRealArray(poly.Normals, 3);
                    if (normal.Count > 0)
                    {
                        for (int i = 0; i < vertices.Count; i++)
                        {
                            float[] n = null;
                            if (i < normal.Count)
                            {
                                n = normal[i];
                            }
                            var p = new Point(vertices[i], n);
                            Points.Add(p);
                        }
                        goto label;
                    }
                }
                for (int j = 0; j < vertices.Count; j++)
                {
                    var p = new Point(vertices[j]);
                    Points.Add(p);
                }

            }
        label:
            Polygons = new();
            foreach (var p in poly.Polygons)
            {
                var pp = new Polygon(p.Points, Effect);
                Polygons.Add(p);
            }*/
   
        }
    }
}
