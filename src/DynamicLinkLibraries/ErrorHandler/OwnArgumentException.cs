namespace ErrorHandler
{
    /// <summary>
    /// Argument exception
    /// </summary>
    public class OwnArgumentException : OwnException
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="message">Message</param>
        public OwnArgumentException(string message = null) : base(message)
        {

        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public OwnArgumentException()
        {

        }

    }
}
