using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
   /// <summary>
    /// Object the sets relative state
    /// </summary>
    public interface ISetRelativeState
    {
        /// <summary>
        /// Sets relative state of objects
        /// </summary>
        /// <param name="coordinates">Coordinates</param>
        /// <param name="matrix">Orientation matrix</param>
        /// <param name="velocity">Velocity</param>
        /// <param name="omega">Angular velocity</param>
        /// <param name="acceleration">Linear acceleration</param>
        /// <param name="eps">Angular acceleration</param>
        void Set(double[] coordinates, double[,] matrix, double[] velocity,
            double[] omega, double[] acceleration, double[] eps);

        /// <summary>
        /// Sets relative state of objects
        /// </summary>
        /// <param name="coordinates">Coordinates</param>
        /// <param name="quaternion">Orientation quaternion</param>
        /// <param name="velocity">Velocity</param>
        /// <param name="omega">Angular velocity</param>
        /// <param name="acceleration">Linear acceleration</param>
        /// <param name="eps">Angular acceleration</param>
        void Set(double[] coordinates, double[] quaternion, double[] velocity,
            double[] omega, double[] acceleration, double[] eps);

        /// <summary>
        /// Sets relative state of objects
        /// </summary>
        /// <param name="coordinates">Coordinates</param>
        /// <param name="quaternion">Orientation quaternion</param>
        /// <param name="matrix">Orientation matrix</param>
        /// <param name="velocity">Velocity</param>
        /// <param name="omega">Angular velocity</param>
        /// <param name="acceleration">Linear acceleration</param>
        /// <param name="eps">Angular acceleration</param>
        void Set(double[] coordinates, double[] quaternion, double[,] matrix, double[] velocity,
            double[] omega, double[] acceleration, double[] eps);
    }
}
