
namespace Abstract3DConverters
{
    public interface IMeshCreator
    {
        string Extension { get; }

        string Directory { get; }

        void Load(string filename);

        Tuple<object, List<AbstractMesh>> Create();

        Dictionary<string, Material> Materials { get; }

        Dictionary<string, Image> Images { get; }
    }
}
