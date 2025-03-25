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
        static public void HandleException(this Exception exception, params object[] obj)
        {
            exceptionHandler?.HandleException(exception, obj);
        }

        /// <summary>
        /// Shows exception double
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void HandleExceptionDouble(this Exception exception, params object[] obj)
        {
            exceptionHandler?.HandleException(exception, obj);
            throw new IncludedException(exception, GetErrorString(obj));
        }

        /// <summary>
        /// Gets error string
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Error string</returns>
        public static string GetErrorString(params object[] obj)
        {
            var s = "";
            foreach (var item in obj)
            {
                s += item.ToString() + " ";
            }
            return s;
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        static public void Log(this string message, params object[] obj)
        {
            exceptionHandler?.Log(message, obj);
        }

        #endregion
    }
}