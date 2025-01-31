namespace Abstract3DConverters.Attributes
{

    /// <summary>
    /// Extensions of mesh creators
    /// </summary>
    public class ExtensionAttribute : Attribute
    {

        /// <summary>
        /// Extensions
        /// </summary>
        public string[] Extensions { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ext">Extensions</param>
        public ExtensionAttribute(string[] ext)
        {
            Extensions = ext;
        }

    }
}
