using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard.Interfaces
{
    /// <summary>
    /// Creates action
    /// </summary>
    public interface IReplaceActionFactory
    {

        /// <summary>
        /// Create action
        /// </summary>
        /// <param name="scada"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        object[] Create(IScadaInterface scada, string name, out Action action);
    }
}
