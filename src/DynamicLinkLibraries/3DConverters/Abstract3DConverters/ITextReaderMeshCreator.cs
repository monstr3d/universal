
namespace Abstract3DConverters
{
    public interface ITextReaderMeshCreator
    {

        string Extension { get; }


        List<AbstractMesh> Create(TextReader reader);

    }
}
