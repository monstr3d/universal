using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Unary function
    /// </summary>
    public interface IUnary
    {
        /// <summary>
        /// Gets value of function
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns></returns>
        double GetValue(double x);

        /// <summary>
        /// Gets derivation of function
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns></returns>
        double GetDerivation(double x);
    }
}
