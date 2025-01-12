using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestCategory.Interfaces;

namespace DataPerformer.TestInterface.Regression
{
    /// <summary>
    /// Test of nonlinear regression
    /// </summary>
    [Serializable()]
    public class IteratorGLMTest : BaseRegressionTest
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of component on desktop</param>
        /// <param name="number">Number of iterations</param>
        public IteratorGLMTest(string name, int number) :
            base(name, number)
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private IteratorGLMTest(SerializationInfo info, StreamingContext context) :
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
            double a = 0;
            global::Regression.Portable.IteratorGLM reg =
                collection.GetObject<global::Regression.Portable.IteratorGLM>(name); // Regression component
            for (int i = 0; i < number; i++)
            {
               a = reg.Iterate();                  // Iteration cylce
            }
            return a;              // returns residual parameter
        }

        #endregion


    }
}
