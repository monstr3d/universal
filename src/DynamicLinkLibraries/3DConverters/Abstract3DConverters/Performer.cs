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

        public T Create<T>(string filename, IMeshCreator creator, IMeshConverter converter, Action < T> action = null) where T : class
        {
            creator.Load(filename);
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