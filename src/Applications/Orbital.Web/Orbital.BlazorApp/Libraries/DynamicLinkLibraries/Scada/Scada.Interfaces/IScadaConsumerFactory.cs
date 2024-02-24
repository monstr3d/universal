using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Interfaces
{
    /// <summary>
    /// Factory of SCADA consumers
    /// </summary>
    public interface IScadaConsumerFactory
    {
        /// <summary>
        /// Creates a consumer from a prototype
        /// </summary>
        /// <param name="prototype">The prototype</param>
        /// <returns>The consumer</returns>
        IScadaConsumer this[object prototype]
        {
            get;
        }

        /// <summary>
        /// Creates a consumer from SCADA and prototype
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="prototype">The prototype</param>
        /// <returns>The consumer</returns>
        IScadaConsumer this[IScadaInterface scada, object prototype]
        {
            get;
        }

    }
}
