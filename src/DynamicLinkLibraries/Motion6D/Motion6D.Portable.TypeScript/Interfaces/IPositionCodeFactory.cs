namespace Motion6D.Portable.TypeScript.Interfaces
{
    public interface IPositionCodeFactory
    {
        List<string> CreateCode(string prefix, object obj, string volume);

    }
}
