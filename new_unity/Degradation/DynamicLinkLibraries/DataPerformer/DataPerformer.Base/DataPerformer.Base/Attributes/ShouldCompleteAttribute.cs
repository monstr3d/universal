using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Attributes
{
    /// <summary>
    /// The "should complete" attribute
    /// </summary>
    public class ShouldCompleteAttribute : Attribute
    {
        bool shouldComplete;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shouldComplete">The "should complete" sing</param>
        public ShouldCompleteAttribute(bool shouldComplete)
        {
            this.shouldComplete = shouldComplete;
        }

        /// <summary>
        /// The "should complete" sing
        /// </summary>
        public bool ShouldComplete
        {
            get
            {
                return shouldComplete;
            }
        }
    }
}
