using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard.Interfaces
{
    /// <summary>
    /// Updates scada
    /// </summary>
    public interface IScadaUpdate
    {
        /// <summary>
        /// The update
        /// </summary>
        Action Update { get; set; }
    }
}
