using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using TestCategory.Interfaces;

namespace SoundService.Test
{
    public class TestInterface : DataPerformer.TestInterface.TestInterfaceDataPerformer
    {

        #region Fields


        #endregion

        #region Ctor

        /// Constructor
        /// </summary>
        /// <param name="writers">Writers</param>
        public TestInterface(IEnumerable<TextWriter> writers)
            : base(writers)
        {
        }


        #endregion

        #region Overriden

  
        #endregion


    }
}
