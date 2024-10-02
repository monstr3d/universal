using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalAlgebra
{
    /// <summary>
    /// Division with reminder
    /// </summary>
    public interface IDivision
    {
        /// <summary>
        /// Divides itself
        /// </summary>
        /// <param name="divisor">Divisor</param>
        /// <param name="reminder">Reminder</param>
        /// <returns>Result of division</returns>
        IDivision Divide(IDivision divisor, out IDivision reminder);

        /// <summary>
        /// Norm
        /// </summary>
        double Norm
        {
            get;
        }

        /// <summary>
        /// The "is zero" sign
        /// </summary>
        bool IsZero
        {
            get;
        }
    }
}
