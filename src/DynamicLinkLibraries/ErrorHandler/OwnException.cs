namespace ErrorHandler
{

    /// <summary>
    /// Own exception
    /// </summary>
    public class OwnException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public OwnException(string message = "") : base(message)
        {
            Init();
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public OwnException()
        {
            Init();
        }

        void Init()
        {

        }


    }
}