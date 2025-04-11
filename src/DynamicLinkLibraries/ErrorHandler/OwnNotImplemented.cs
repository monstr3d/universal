namespace ErrorHandler
{
    /// <summary>
    /// Own not implemented excerption
    /// </summary>
    public class OwnNotImplemented : OwnException
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="message">Message</param>
        public OwnNotImplemented(string message = null) : base(message)
        {

        }
        /// <summary>
        /// Constructor 
        /// </summary>
        public OwnNotImplemented()
        {

        }

    }
}
