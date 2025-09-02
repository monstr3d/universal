using System;

namespace Diagram.UI.Attributes
{
    /// <summary>
    /// Attributes of code creation
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CodeCreatorAttribute : Attribute
    {
        /// <summary>
        /// Allows initial alias state
        /// </summary>
        public bool InitialState
        {
            get;
            set;
        } = false;

        /// <summary>
        /// The is system of differential equations sign
        /// </summary>
        public bool IsSysemOfDifferentialEquations
        {
            get;
            set;
        } = false;

    }
}
