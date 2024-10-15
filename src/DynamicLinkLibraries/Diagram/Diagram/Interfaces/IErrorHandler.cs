using System;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// The error handler
    /// </summary>
    public interface IErrorHandler
    {
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        void ShowError(Exception exception, object obj);

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        void ShowMessage(string message, object obj);
    }
}
