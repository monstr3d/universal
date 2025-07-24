using System.Net.NetworkInformation;

namespace ErrorHandler
{
    /// <summary>
    /// Included exception
    /// </summary>
    public class IncludedException : OwnException
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
        /// Object
        /// </summary>
        public object Object { get; init; }

        public IncludedException(string message, object obj) : base(message)
        {
            Object = obj;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exception">Include exception</param>
        /// <param name="message">Message</param>
        protected IncludedException(Exception exception, object obj = null) : base(exception.Message)
        {
            Exception = exception;
            Object = obj;
        }

        public static IncludedException Get(Exception exception, object obj = null)
        {
            if (exception is IncludedException ic)
            {
                return ic;
            }
            return new IncludedException(exception, obj);
        }
    }
}
