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

        public object Create(AbstractMesh mesh, IMeshCreator meshCreator, Dictionary<string, object> materials)
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
                var ch = Create(child, meshCreator, materials);
                meshCreator.Add(o, ch);
            }
            return o;
        }

        public IEnumerable<object> Create(IEnumerable<AbstractMesh> meshes, IMeshCreator c, Dictionary<string, object> materials)
        {
            foreach (var mesh in meshes)
            {
                yield return Create(mesh, c, materials);
            }
        }
    }
}