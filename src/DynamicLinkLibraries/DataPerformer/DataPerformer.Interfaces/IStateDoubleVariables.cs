using System.Collections.Generic;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// State variables
    /// </summary>
    public interface IStateDoubleVariables
    {
        /// <summary>
        /// Variables
        /// </summary>
        List<string> Variables
        {
            get;
        }

        /// <summary>
        /// State vector
        /// </summary>
        double[] Vector
        {
            get;
            set;
        }

        /// <summary>
        /// Sets vector
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="offset">Offset</param>
        /// <param name="length">Length</param>
        void Set(double[] input, int offset, int length);
    }
}
