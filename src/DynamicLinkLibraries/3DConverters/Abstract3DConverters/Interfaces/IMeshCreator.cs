using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Interfaces
{
    public interface IMeshCreator
    {

        string Directory { get; }

        void Load(string filename);

        Tuple<object, List<AbstractMesh>> Create();

        Dictionary<string, Material> Materials { get; }

        Dictionary<string, Image> Images { get; }
    }
}
