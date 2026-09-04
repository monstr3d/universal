namespace ErrorHandler
{
    /// <summary>
    /// Argument null exception
    /// </summary>
    public class OwnArgumentNullException : OwnException
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="message">Message</param>
        public OwnArgumentNullException(string message = null) : base(message)
        {

        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public OwnArgumentNullException()
        {

        }

    }
}
