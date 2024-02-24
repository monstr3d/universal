using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Objects of this interface performs post serialize operation
    /// </summary>
    public interface IPostSerialize
    {
        /// <summary>
        /// Operation after deserialization
        /// </summary>
        void PostSerialize();
    }
}
