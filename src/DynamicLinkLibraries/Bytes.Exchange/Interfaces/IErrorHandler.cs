using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange.Interfaces
{
    /// <summary>
    /// Error Handler
    /// </summary>
    public interface IErrorHandler
    {
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="exception">Exception</param>
        void ShowError(object sender, Exception exception);
    }
}
