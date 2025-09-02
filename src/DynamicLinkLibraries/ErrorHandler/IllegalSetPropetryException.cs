namespace ErrorHandler
{
    /// <summary>
    /// Illegal propery
    /// </summary>
    public class IllegalSetPropetryException : OwnException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public IllegalSetPropetryException(string message = "") : base(message) 
        { 
        }
    }

    /// <summary>
    /// Write prohibited exception
    /// </summary>
    public class WriteProhibitedException : OwnException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public WriteProhibitedException(string message = "") : base(message)
        {
        }
    }
}
