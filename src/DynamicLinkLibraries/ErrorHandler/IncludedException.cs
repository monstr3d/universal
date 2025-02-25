namespace ErrorHandler
{
    /// <summary>
    /// Included exception
    /// </summary>
    public class IncludedException : Exception
    {
        /// <summary>
        /// Included exception
        /// </summary>
        public Exception Exception
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exception">Include exception</param>
        /// <param name="message">Message</param>
        public IncludedException(Exception exception, string message = null) : base(message)
        {
            Exception = exception;
        }
    }
}
