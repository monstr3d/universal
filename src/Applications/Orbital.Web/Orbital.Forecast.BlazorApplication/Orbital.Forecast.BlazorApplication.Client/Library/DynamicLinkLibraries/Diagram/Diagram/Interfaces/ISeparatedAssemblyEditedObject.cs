using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Object which holds editor in separated assembly
    /// </summary>
    public interface ISeparatedAssemblyEditedObject
    {
        /// <summary>
        /// Bytes of assembly
        /// </summary>
        byte[] AssemblyBytes
        {
            get;
            set;
        }

        /// <summary>
        /// Editor
        /// </summary>
        ISeparatedPropertyEditor Editor
        {
            get;
            set;
        }


        /// <summary>
        /// First load
        /// </summary>
        void FirstLoad();
    }
}
