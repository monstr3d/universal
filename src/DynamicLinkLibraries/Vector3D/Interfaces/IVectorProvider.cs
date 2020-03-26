using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3D.Interfaces
{
    /// <summary>
    /// Provider of vectors
    /// </summary>
    public interface IVectorProvider
    {
        /// <summary>
        /// Count of vectors
        /// </summary>
        int Count
        { get; }

        /// <summary>
        /// Gets i - th vector
        /// </summary>
        /// <param name="i"></param>
        /// <returns>The i-th vector</returns>
        double[] this[int i]
        { get; }
    }
}
