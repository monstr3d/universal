using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard
{
    /// <summary>
    /// Indicator
    /// </summary>
    public interface IIndicator
    {
        /// <summary>
        /// Update action
        /// </summary>
        Action Update { get; }

        /// <summary>
        /// The name of parameter
        /// </summary>
        string Parameter { get; }


        /// <summary>
        /// Set value
        /// </summary>
        object Value { set; }

        /// <summary>
        /// Type
        /// </summary>
        object Type { get; }


        /// <summary>
        /// The "Is Active" sign
        /// </summary>
        bool IsActive { get; set; }
    }
}
