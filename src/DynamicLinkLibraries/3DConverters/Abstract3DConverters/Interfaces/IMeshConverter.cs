using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Interfaces
{
    public interface IMeshConverter
    {

        string Directory { get; set;  }

        Dictionary<string, Material> Materials
        {
            set;
        }

        Dictionary<string, Image> Images
        {
            set;
        }

        IMaterialCreator MaterialCreator { get; }


        object Create(AbstractMesh mesh);

        void SetMaterial(object mesh, object material);

        void Add(object mesh, object child);

        object Combine(IEnumerable<object> meshes);

        void SetTransformation(object mesh, float[] transformation);
    }
}
