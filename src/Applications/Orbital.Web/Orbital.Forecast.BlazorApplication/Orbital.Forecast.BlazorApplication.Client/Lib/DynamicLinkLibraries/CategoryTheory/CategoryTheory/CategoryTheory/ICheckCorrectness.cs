using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Object which correcteness should be checked
    /// </summary>
    public interface ICheckCorrectness
    {
        /// <summary>
        /// Checks its correctness
        /// </summary>
        void CheckCorrectness();
    }

}
