using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Interfaces
{
    public interface IMeshCreator
    {
        string Extension { get; }

        string Directory { get; }


        void Load(Stream stream);

        IEnumerable<AbstractMesh> Meshes { get; }

        Dictionary<string, Material> Materials { get; }
 
        Dictionary<string, Image> Images { get; }
    }
}
