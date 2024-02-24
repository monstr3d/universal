using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Provider of matrix
    /// </summary>
    public interface IMatrix
    {
        /// <summary>
        /// Matrix
        /// </summary>
        Func<double[,]> Matrix
        {
            get;
        }

        /// <summary>
        /// Dimesion
        /// </summary>
        int[] Dimension
        {
            get;
        }

    }
}
