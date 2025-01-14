using System;
using System.ComponentModel.DataAnnotations;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters
{
    public class Performer
    {

        public Performer()
        {

        }

        #region Service


        #endregion

        public T CreateAll<T>(string fileinput, Stream stream, string outExt, string outComment, Action<T> act) where T : class
        {
            var creator = fileinput.ToMeshCreator(stream);
            var p = new Performer();
            var converter = outExt.ToMeshConvertor(outComment);
            var res = p.Create<T>(creator, converter, act);
            return res;
        }

        public string CreateAll(string fileinput, Stream stream, string outExt, string outComment, Action<object> act = null)
        {
            var creator = fileinput.ToMeshCreator(stream);
            var p = new Performer();
            var converter = outExt.ToMeshConvertor(outComment);
            var res = p.Create<object>(creator, converter, act);
            var sr = converter as IStringRepresentation;
            var r = sr.ToString(res);
            return r;
        }

        public T Create<T>(AbstractMesh mesh, IMeshConverter meshConverter) where T : class
        {
            IMaterialCreator materialCreator = meshConverter.MaterialCreator;
            object o = meshConverter.Create(mesh);
            var trans = mesh.TransformationMatrix;
            if (trans != null)
            {
                meshConverter.SetTransformation(o, trans);
            }
            var mt = mesh.GetMaterial(materialCreator);
            if (mt != null)
            {
                meshConverter.SetMaterial(o, mt);
            }
            foreach (var child in mesh.Children)
            {
                var ch = Create<T>(child, meshConverter);
                meshConverter.Add(o, ch);
            }
            return o as T;
        }

        public IEnumerable<T> Create<T>(IEnumerable<AbstractMesh> meshes, IMeshConverter converter) where T : class
        {
            return meshes.Select(e => Create<T>(e, converter)).ToList();
        }

        public T Combine<T>(IEnumerable<AbstractMesh> meshes, IMeshConverter converter) where T : class
        {
            var enu = Create<T>(meshes, converter);
            return converter.Combine(enu) as T;
        }

        public T Create<T>(IMeshCreator creator, IMeshConverter converter, Action <T> action = null) where T : class
        {
            var meshes = creator.Meshes;
            converter.Images = creator.Images;
            converter.Materials = creator.Materials;
            var res = Combine<T>(meshes, converter);
            if (action != null)
            {
                action(res);
            }
            return res;
        }
    }
}