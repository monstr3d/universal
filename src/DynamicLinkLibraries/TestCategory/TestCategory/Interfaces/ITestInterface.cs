using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces;

namespace TestCategory.Interfaces
{
    /// <summary>
    /// Test interface
    /// </summary>
    public interface ITestInterface
    {
        /// <summary>
        /// Edit test object
        /// </summary>
        /// <param name="test">Prior test object</param>
        /// <param name="collection">Collection of components</param>
        /// <returns>Post test object</returns>
        ITest Edit(ITest test, IComponentCollection collection);

        /// <summary>
        /// Creates test report
        /// </summary>
        /// <param name="test">Prior test object</param>
        /// <param name="collection">Collection of components</param>
        void CreateTestReport(ITest test, IComponentCollection collection);
    }
}
