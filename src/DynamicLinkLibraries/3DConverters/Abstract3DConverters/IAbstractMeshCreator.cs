
namespace Abstract3DConverters
{
    public interface IAbstractMeshCreator
    {
        string Extension { get; }

        Tuple<object, List<AbstractMesh>> Create(string filename);
    }
}
