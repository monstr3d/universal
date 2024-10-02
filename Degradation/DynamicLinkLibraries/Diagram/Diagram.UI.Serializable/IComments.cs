using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Diagram.UI
{

    /// <summary>
    /// Object with comments
    /// </summary>
    public interface IComments
    {
        /// <summary>
        /// Comments
        /// </summary>
        ArrayList Comments
        {
            get;
            set;
        }
    }

}
