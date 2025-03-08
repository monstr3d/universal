namespace ErrorHandler
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionErrorHandler
    {
        #region Fields

        /// <summary>
        /// Error handler
        /// </summary>
        static IExceptionHandler? exceptionHandler = null;

        #endregion

        #region Members

        /// <summary>
        /// Sets error handler
        /// </summary>
        /// <param name="handler">The error handler</param>
        public static void Set(this IExceptionHandler handler)
        {
            exceptionHandler = handler;
        }

        /// <summary>
        /// Error handler
        /// </summary>
        public static IExceptionHandler? ErrorHandler => exceptionHandler;
       
        /// <summary>
        /// Shows exception (extension method)
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void HandleException(this Exception exception, object obj = null)
        {
            exceptionHandler?.HandleException(exception, obj);
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        static public void Log(this string message, object obj = null)
        {
            exceptionHandler?.Log(message, obj);
        }

        #endregion
    }
}