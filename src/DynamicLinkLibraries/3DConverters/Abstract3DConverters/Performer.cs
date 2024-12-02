using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collada;

namespace Abstract3DConverters
{
    public class Performer
    {

        public Performer()
        {

        }

        #region Service


        #endregion

        public T Create<T>(AbstractMesh mesh, IMeshCreator meshCreator, Dictionary<string, object> materials, IMaterialCreator materialCreator = null) where T : class
        {
            object o = meshCreator.Create(mesh);
            var trans = mesh.TransformationMatrix;
            if (trans != null)
            {
                meshCreator.SetTransformation(o, trans);
            }
            var mt = mesh.GetMaterial(materials, materialCreator);
            if (mt != null)
            {
                meshCreator.SetMaterial(o, mt);
            }
            foreach (var child in mesh.Children)
            {
                var ch = Create<T>(child, meshCreator, materials, materialCreator);
                meshCreator.Add(o, ch);
            }
            return o as T;
        }

        public IEnumerable<T> Create<T>(object o, IEnumerable<AbstractMesh> meshes, IMeshCreator c, Dictionary<string, object> materials, IMaterialCreator materialCreator = null) where T : class
        {
            c.Init(o);
            foreach (var mesh in meshes)
            {
                yield return Create<T>(mesh, c, materials, materialCreator);
            }
        }

        public T Combine<T>(object o, IEnumerable<AbstractMesh> meshes, IMeshCreator c, Dictionary<string, object> materials, IMaterialCreator materialCreator = null) where T : class
        {
            var enu = Create<T>(o, meshes, c, materials, materialCreator);
            return c.Combine(enu) as T;
        }
    }
}