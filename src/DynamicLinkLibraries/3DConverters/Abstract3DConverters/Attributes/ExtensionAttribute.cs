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
        /// Full image path
        /// </summary>
        public bool ImagePathFull { get; private set; }
      
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ext">Extensions</param>
        /// <param name="imagePathFull">FullImagePath</param>
        public ExtensionAttribute(string[] ext, bool imagePathFull = false)
        {
            Extensions = ext;
            ImagePathFull = imagePathFull;
        }

    }
}
