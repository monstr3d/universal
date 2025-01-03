﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
using Abstract3DConverters.Meshes;
using Collada.Converter.Creators;
using Collada141;

namespace Collada.Converter.Meshes
{
    internal class AbstractMeshCollada14 : AbstractMeshNamedMaterial
    {
        Collada14MeshCreator converter;

        instance_geometry[] instance_geometry;

        instance_geometry geom;

        geometry geometry;

        bind_material bind_material;

        internal AbstractMeshCollada14(node node, AbstractMeshPolygon parent, Collada14MeshCreator converter) : base(node.name, parent, converter)
        {
            this.converter = converter;
            instance_geometry = node.instance_geometry;
            if (instance_geometry != null)
            {
                CreateInstanceGeometry();
            }
        }

        void CreateInstanceGeometry()
        {
            foreach (var g in instance_geometry)
            {
                if (g != null & geom != null)
                {
                    throw new Exception();
                }
                geom = g;
            }
            CreateGeometry();
        }

        void CreateGeometry()
        {
            bind_material = geom.bind_material;
            if (geom.url != null)
            {
                var url = geom.url;
                if (url != null)
                {
                    if (url.Length > 1)
                    {
                        url = url.Substring(1);
                        if (converter.Geometries.ContainsKey(url))
                        {
                            geometry = converter.Geometries[url];
                        }
                    }
                }
            }
            CreateMaterial();
            CreateMesh();
        }

        void CreateMesh()
        {
            var mesh = geometry.Item as mesh;
            if (mesh.Items != null)
            {

                var vert = mesh.source[0];
                var v = vert.Item as float_array;
                Vertices = s.ToReal3Array(s.Convert(v.Values));
                var txt = mesh.source[2].Item as float_array;
                Textures = s.ToReal2Array(s.Convert(txt.Values));
                var norm = mesh.source[1].Item as float_array;
                Normals = s.ToReal3Array(s.Convert(norm.Values));
                var pc = mesh.Items.Length;
                if (pc != 1)
                {

                }
                var poly = mesh.Items[0] as polylist;
                var vcount = s.ToRealArray<int>(poly.vcount);
                var cc = 0;
                List<int[]> ind = null;
                foreach (var item in vcount)
                {
                    cc += item;
                }
                var arr = s.ToRealArray<int>(poly.p);
                if (arr.Length == 3 * cc)
                {
                    ind = s.ToReal3Array<int>(poly.p);
                }
                else if (arr.Length == 3 * cc)
                {
                    ind = s.ToReal2Array<int>(poly.p);
                }
                else
                {
                    throw new Exception();
                }
                var j = 0;
                foreach (var vc in vcount)
                {
                    var l = new List<Tuple<int, int, int, float[]>>();
                    for (int i = 0; i < vc; i++)
                    {
                        var ii = ind[j];
                        if (ii[0] > Vertices.Count)
                        {

                        }
                        if (ii[1] > Textures.Count)
                        {

                        }
                        if (ii[2] > Normals.Count)
                        {

                        }
                        if (ii.Length == 3)
                        {
                            if (ii[0] != j)
                            {
                                //     throw new Exception();
                            }
                        }
                        var t = new Tuple<int, int, int, float[]>(ii[0], ii[1], ii[2], Textures[ii[1]]);
                        l.Add(t);
                        ++j;
                    }
                    var mt = poly.material;
                    Abstract3DConverters.Materials.Material mat = creator.Materials[mt];


                    var p = new Polygon(l, mat);

                    Polygons.Add(p);
                }

            }
        }

        void CreateMaterial()
        {
            if (bind_material.technique_common != null)
            {
                var tc = bind_material.technique_common;
                if (tc.Length > 0)
                {
                    var th = bind_material.technique_common[0];
                    var v = th.symbol;
                    if (converter.Materials.ContainsKey(v))
                    {
                        Material = converter.Materials[v];
                    }
                }
            }
        }
    }
}
