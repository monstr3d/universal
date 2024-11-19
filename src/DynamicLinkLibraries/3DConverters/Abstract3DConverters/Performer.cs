using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class Performer
    {
        public Performer()
        {

        }

        public T Create<T>(AbstractMesh mesh, IMeshCreator meshCreator, Dictionary<string, object> materials) where T : class
        {
            object o = meshCreator.Create(mesh);
            var mat = mesh.Material;
            if (mat != null)
            {
                object mt = materials[mat];
                meshCreator.SetMaterial(o, mt);
            }
            foreach (var child in mesh.Children)
            {
                var ch = Create<T>(child, meshCreator, materials);
                meshCreator.Add(o, ch);
            }
            return o as T;
        }

        public IEnumerable<T> Create<T>(IEnumerable<AbstractMesh> meshes, IMeshCreator c, Dictionary<string, object> materials) where T : class
        {
            c.Init(meshes);
            foreach (var mesh in meshes)
            {
                yield return Create<T>(mesh, c, materials);
            }
        }

        public T Combine<T>(IEnumerable<AbstractMesh> meshes, IMeshCreator c, Dictionary<string, object> materials) where T : class
        {
            var enu = Create<T>(meshes, c, materials);
            return c.Combine(enu) as T;
        }
    }
}