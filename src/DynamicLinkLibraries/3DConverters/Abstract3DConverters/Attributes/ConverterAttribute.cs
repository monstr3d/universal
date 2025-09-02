namespace Abstract3DConverters.Attributes
{
    /// <summary>
    /// Attribute of mesh converter
    /// </summary>
    public class ConverterAttribute : Attribute
    {
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// Comment
        /// </summary>
        public bool TrianglesOnly { get; private set; }

        /// <summary>
        /// Requires absolute calculation
        /// </summary>
        public bool RequiresAbsolute { get; private set;}

        
        /// <summary>
        /// Should separate textures
        /// </summary>
        public bool ShouldSeparateTextures { get; private set; }

  
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="extension">Extension</param>
        /// <param name="trianglesOnly">Supports only triangles</param>
        /// <param name="requiresAbsolute">Requires absolute calculation</param>
        /// <param name="comment">Comment</param>
        public ConverterAttribute(string extension, bool trianglesOnly = false, bool requiresAbsolute = false, 
           bool shouldSeparateTextures  = false, string comment = null)
        {
            Extension = extension;
            TrianglesOnly = trianglesOnly;
            RequiresAbsolute = requiresAbsolute;
            ShouldSeparateTextures = shouldSeparateTextures;
            Comment = comment;
        }
    }
}
