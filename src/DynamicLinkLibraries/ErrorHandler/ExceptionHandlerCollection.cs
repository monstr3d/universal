namespace ErrorHandler
{
    /// <summary>
    /// Collection of handlers
    /// </summary>
    public class ExceptionHandlerCollection : IExceptionHandler
    {
        #region Fields

        IExceptionHandler[] handlers;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handlers">Handler</param>
        public ExceptionHandlerCollection(IEnumerable<IExceptionHandler> handlers)
        {
            this.handlers = handlers.ToArray();
        }

        #endregion

        #region IExceptionHandler Members

        /// <summary>
        /// Handles an exception
        /// </summary>
        /// <typeparam name="T">Type of exception</typeparam>
        /// <param name="exception">The exception</param>
        void IExceptionHandler.HandleException<T>(T exception, object? obj)
        {
            foreach (var handler in handlers)
            {
                handler.HandleException<T>(exception, obj);
            }
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        void IExceptionHandler.Log(string message, object? obj)
        {
            foreach (var handler in handlers)
            {
                handler.Log(message, obj);
            }
        }

        #endregion
    }
}
