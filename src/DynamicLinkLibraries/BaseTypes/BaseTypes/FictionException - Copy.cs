using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes.Attributes;

namespace BaseTypes
{
    /// <summary>
    /// Fiction exception
    /// </summary>
    [Fiction]
    public class FictionException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public FictionException(string message)
            : base(message)
        {
        }
    }
}
