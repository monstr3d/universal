
using System.Reflection;

namespace Abstract3DConverters
{
    public interface IMeshCreator
    {
        Assembly Assembly { get; }

        Dictionary<string, Material> Materials
        {
            set;
        }

        Dictionary<string, Image> Images
        {
            set;
        }
            

        void Init(object obj);
       
        object Create(AbstractMesh mesh);

        void SetMaterial(object mesh, object material);

        void Add(object mesh, object child);

        object Combine(IEnumerable<object> meshes);

        void SetTransformation(object mesh, float[] transformation);
    }
}
