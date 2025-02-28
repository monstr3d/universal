using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Constructor
        /// </summary>
        /// <param name="extension">Extension</param>
        /// <param name="comment">Comment</param>
        public ConverterAttribute(string extension, bool trianglesOnly = false, string comment = null)
        {
            Extension = extension;
            Comment = comment;
            TrianglesOnly = trianglesOnly;
        }
    }
}
