using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Finite derivation matrix
    /// </summary>
    public interface IFiniteDerivationMatrix : IMatrix
    {
        /// <summary>
        /// Finite difference
        /// </summary>
        double[] FiniteDifference
        {
            get;
            set;
        }

        /// <summary>
        /// State
        /// </summary>
        double[] State
        {
            get;
            set;
        }
        
        /// <summary>
        /// Output
        /// </summary>
        double[] Output
        {
            get;
        }

        /// <summary>
        /// Object transformer
        /// </summary>
        IObjectTransformer Transformer
        {
            get;
        }

    }
}
