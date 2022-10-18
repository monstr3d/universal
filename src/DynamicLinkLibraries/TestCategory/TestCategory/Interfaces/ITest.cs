using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces;

namespace TestCategory.Interfaces
{
    /// <summary>
    /// Test
    /// </summary>
    public interface ITest
    {
        /// <summary>
        /// Tests collection of components
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <returns>Test result</returns>
        Tuple<bool, object> this[IComponentCollection collection]
        {
            get;
        }
    }
}
