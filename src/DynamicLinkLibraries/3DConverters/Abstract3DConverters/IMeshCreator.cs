using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public interface IMeshCreator
    {
        Assembly Assembly { get; }

        void Init(object obj);
        object Create(AbstractMesh mesh);

        void SetMaterial(object mesh, object material);

        public void Add(object mesh, object child);

        public object Combine(IEnumerable<object> meshes);
    }
}
