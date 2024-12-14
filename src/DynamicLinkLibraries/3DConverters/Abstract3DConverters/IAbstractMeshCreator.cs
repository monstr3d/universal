
namespace Abstract3DConverters
{
    public interface IAbstractMeshCreator
    {
        string Extension { get; }

        string Directory { get; }

        void Load(string filename);

        Tuple<object, List<AbstractMesh>> Create(IAbstractMeshCreator creator);

        Dictionary<string, Material> Materials { get; }

        Dictionary<string, Image> Images { get; }
    }
}
