using System;
using System.Collections.Generic;
using System.Text;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Serialized frame
    /// </summary>
    public class SerializableFrame : ISetRelativeState
    {
        #region ISetRelativeState Members

        void ISetRelativeState.Set(double[] coordinates, double[,] matrix, double[] velocity, double[] omega, double[] acceleration, double[] eps)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void ISetRelativeState.Set(double[] coordinates, double[] quaternion, double[] velocity, double[] omega, double[] acceleration, double[] eps)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void ISetRelativeState.Set(double[] coordinates, double[] quaternion, double[,] matrix, double[] velocity, double[] omega, double[] acceleration, double[] eps)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
