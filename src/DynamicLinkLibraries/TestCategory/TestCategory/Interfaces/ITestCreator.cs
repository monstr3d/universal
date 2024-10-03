using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCategory.Interfaces
{
    /// <summary>
    /// Creator of tests
    /// </summary>
    public interface ITestCreator
    {
        /// <summary>
        /// Processes Test
        /// </summary>
        /// <param name="i">Number</param>
        /// <param name="test">Test</param>
        /// <param name="dictionary">Dictionary</param>
        /// <returns>True in success</returns>
        bool Process(int i, ITest test, 
            Dictionary<string, object[]> dictionary);

        /// <summary>
        /// Creates test
        /// </summary>
        /// <param name="name">Nest name</param>
        /// <param name="number">Test number</param>
        /// <param name="label">Label of object</param>
        /// <param name="collection">Collection of object</param>
        /// <returns>The test</returns>
        ITest Create(out string name, uint number, IObjectLabel label, 
            IComponentCollection collection);

        /// <summary>
        /// Checks whether object is admissible
        /// </summary>
        /// <param name="o">The object</param>
        /// <param name="cob">The category object</param>
        /// <returns>True if admissible</returns>
        bool IsAdmissible(object o, ICategoryObject cob);

    }
}
