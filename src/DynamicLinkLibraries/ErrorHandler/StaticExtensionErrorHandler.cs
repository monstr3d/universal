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
        static IErrorHandler? errorHandler = null;

        #endregion

        #region Members

        /// <summary>
        /// Sets error handler
        /// </summary>
        /// <param name="handler">The error handler</param>
        public static void Set(this IErrorHandler handler)
        {
            errorHandler = handler;
        }

        /// <summary>
        /// Error handler
        /// </summary>
        public static IErrorHandler? ErrorHandler => errorHandler;
       
        /// <summary>
        /// Shows exception (extension method)
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void ShowError(this Exception exception, object? obj = null)
        {
            errorHandler?.ShowError(exception, obj);
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        static public void ShowMessage(this string message, object obj = null)
        {
            errorHandler?.ShowMessage(message, obj);
        }

        #endregion
    }
}