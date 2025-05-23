﻿namespace ErrorHandler
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

        }


        /// <summary>
        /// Constructor
        /// </summary>
        public OwnException()
        {

        }


    }
}