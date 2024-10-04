using System;

namespace DataPerformer.Attributes
{
    /// <summary>
    /// Calculation priority
    /// </summary>
    public class CalculationPriorityAttribute : Attribute
    {
        #region Fields

        /// <summary>
        /// Priority
        /// </summary>
        int priority = 0;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="priority">Priority</param>
        public CalculationPriorityAttribute(int priority)
        {
            this.priority = priority;
        }

        #endregion

        /// <summary>
        /// Priority
        /// </summary>
        public int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
    }
}
