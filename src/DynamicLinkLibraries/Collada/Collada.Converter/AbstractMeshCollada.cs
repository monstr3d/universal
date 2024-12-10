using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    internal class AbstractMeshCollada : AbstractMeshPolygon
    {
        Collada14Converter converter;

        instance_geometry[] instance_geometry;

        instance_geometry geom;

        geometry geometry;

        bind_material bind_material;


        internal AbstractMeshCollada(node node, Collada14Converter converter) : base(node.name)
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
                var poly = mesh.Items[0] as polylist;
                var ind = s.ToReal3Array<int>(poly.p);
                var vert = mesh.source[0];
                var v = vert.Item as float_array;
                Vertices = s.ToReal3Array(s.Convert(v.Values));
                var txt = mesh.source[2].Item as float_array;
                Textures = s.ToReal2Array(s.Convert(txt.Values));
                var norm = mesh.source[1].Item as float_array;
                Normals = s.ToReal3Array(s.Convert(norm.Values));
                for (int i = 0; i < ind.Count; i++)
                {
                    
                }

            }
            //te
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
