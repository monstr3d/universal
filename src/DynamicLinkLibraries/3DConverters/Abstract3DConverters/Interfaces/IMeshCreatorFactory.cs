namespace Abstract3DConverters.Interfaces
{
    public interface IMeshCreatorFactory
    {
        IMeshCreator this[string extension, Stream stream] { get;  }
    }
}
