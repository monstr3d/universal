using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Interfaces
{
    public interface IErrorHandler
    {
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Object</param>
        void ShowError(Exception exception, object obj);

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="obj">Object</param>
        void ShowMessage(string message, object obj);
    }
}
