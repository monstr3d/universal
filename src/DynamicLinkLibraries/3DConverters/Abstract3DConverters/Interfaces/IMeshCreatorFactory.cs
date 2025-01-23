namespace Abstract3DConverters.Interfaces
{
    public interface IMeshCreatorFactory
    {
        IMeshCreator this[string extension, byte[] bytes] { get;  }
    }
}
