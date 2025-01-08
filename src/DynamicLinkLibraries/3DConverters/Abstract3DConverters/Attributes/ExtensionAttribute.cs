namespace Abstract3DConverters.Attributes
{
    public class ExtensionAttribute : Attribute
    {

        public string[] Extensions { get; private set; }

        public ExtensionAttribute(string[] ext)
        {
            Extensions = ext;
        }

    }
}
