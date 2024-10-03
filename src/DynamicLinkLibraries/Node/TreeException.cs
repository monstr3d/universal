using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralNode
{
    /// <summary>
    /// Exception of tree
    /// </summary>
    public class TreeException : Exception
    {
        /// <summary>
        /// Associated object
        /// </summary>
        private object o;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="o">Associated object</param>
        public TreeException(object o)
        {
            this.o = o;
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
        {
            get
            {
                return o;
            }
        }
    }
}
