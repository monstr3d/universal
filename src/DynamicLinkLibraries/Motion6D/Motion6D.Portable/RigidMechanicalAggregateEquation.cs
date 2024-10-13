using System;
using System.Collections.Generic;
using System.Text;


using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Equation of rigid mechanical object
    /// </summary>
    public class RigidMechanicalAggregateEquation : MechanicalAggregateEquation
    {
        #region Fields

        /// <summary>
        /// Inverted matrix
        /// </summary>
        double[,] invertedMatrix;

        /// <summary>
        /// Final matrix
        /// </summary>
        double[,] finalMatrix;
        

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="aggregate">Root aggregate</param>
        internal RigidMechanicalAggregateEquation(AggregableWrapper aggregate)
            : base(aggregate)
        {
            CalculateMatrixes();
            if (matrix.GetLength(0) == 0)
            {
                return;
            }
            realMatrix.Invert(matrix, invertedMatrix);
            realMatrix.Multiply(forcesToAccelerations, invertedMatrix, finalMatrix);
        }

        #endregion

        #region Overriden Members
 
        /// <summary>
        /// Initialization
        /// </summary>
        protected override void Init()
        {
            invertedMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            finalMatrix = new double[vector.Length, links.Count * 6];
            base.Init();
        }
 

        #endregion

        #region Specific Membes

        /// <summary>
        /// Calculates Link accelerations
        /// </summary>
        protected override void CalculateLinkAccelerations()
        {
            CalculateResidues();
            realMatrix.Multiply(finalMatrix, connectionResidues, addAcceleration);
        }
 
        #endregion

    }
}
