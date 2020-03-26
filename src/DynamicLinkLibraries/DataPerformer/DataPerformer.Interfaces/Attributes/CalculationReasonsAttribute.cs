using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces.Attributes
{
    /// <summary>
    /// Reason of calculation
    /// </summary>
    public class CalculationReasonsAttribute : Attribute
    {
        #region Fields

        string[] reasons;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reasons">reasons</param>
        public CalculationReasonsAttribute(string[] reasons)
        {
            this.reasons = reasons;
        }

        #region Members

        /// <summary>
        /// Reasons
        /// </summary>
        public string[] Reasons
        {
            get
            {
                return reasons;
            }
        }

        #endregion
    }
}
