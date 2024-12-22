using System.Reflection;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Interfaces
{
    public interface IMeshConverter
    {
        Assembly Assembly { get; }

        string Directory { get; }

        Dictionary<string, Material> Materials
        {
            set;
        }

        IMaterialCreator MaterialCreator { get; }

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
