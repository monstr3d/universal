using System;

namespace Unity.Standard.Interfaces
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
        object Value { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        object Type { get; }

        /// <summary>
        /// The "Is Active" sign
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Global action
        /// </summary>
        Action<string> Global { get; }
    }

}
