using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Attributes
{
    /// <summary>
    /// Reason of display
    /// </summary>
    public class DisplayReasonsAttribute : Attribute
    {
        #region Fields

        string[] reasons;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reasons">reasons</param>
        public DisplayReasonsAttribute(string[] reasons)
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