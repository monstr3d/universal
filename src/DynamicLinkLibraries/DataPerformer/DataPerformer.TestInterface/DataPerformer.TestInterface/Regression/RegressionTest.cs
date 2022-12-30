using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using TestCategory.Interfaces;

using Diagram.UI.Interfaces;
using Diagram.UI;

using Regression;


namespace DataPerformer.TestInterface.Regression
{
    /// <summary>
    /// Test of nonlinear regression
    /// </summary>
    [Serializable()]
    class RegressionTest : BaseRegressionTest
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of component on desktop</param>
        /// <param name="number">Number of iterations</param>
        internal RegressionTest(string name, int number) : 
            base(name, number)
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private RegressionTest(SerializationInfo info, StreamingContext context) : 
            base(info, context)
        {
        }


        #endregion

        #region Overriden

        /// <summary>
        /// Calculates value of residual parameter
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        /// <returns>Residual parameter</returns>
        protected override double GetValue(IComponentCollection collection)
        {
            global::Regression.Portable.AliasRegression reg =
                collection.GetObject<global::Regression.Portable.AliasRegression>(name); // Regression component
            for (int i = 0; i < number; i++)
            {
                reg.FullIterate();                  // Iteration cylce
            }
            return reg.SquareResidual;              // returns residual parameter
        }

        #endregion

    }
}
