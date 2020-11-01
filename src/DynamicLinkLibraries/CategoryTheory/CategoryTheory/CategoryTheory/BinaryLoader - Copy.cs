using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// The binary loader
    /// </summary>
    public abstract class BinaryLoader
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static private BinaryLoader obj;

        /// <summary>
        /// Singleton
        /// </summary>
        static public BinaryLoader Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        /// <summary>
        /// Gets blob by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The blob</returns>
        public abstract byte[] this[string id]
        {
            get;
        }
    }
}
