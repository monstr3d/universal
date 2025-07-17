using System;

using CategoryTheory;

using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Associated Exception
    /// </summary>
    public class AssociatedException : OwnException
    {
        #region Fields

        /// <summary>
        /// Associated addition
        /// </summary>
        protected AssociatedAddition associated;

        /// <summary>
        /// Internal exception
        /// </summary>
        protected Exception exception;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="associated">Associated addition</param>
        /// <param name="exception">Internal exception</param>
        protected AssociatedException(AssociatedAddition associated,
            Exception exception)
        {
            this.associated = associated;
            this.exception = exception;
        }

        #endregion

        #region Members

        /// <summary>
        /// Associated addition
        /// </summary>
        public AssociatedAddition Associated
        {
            get
            {
                return associated;
            }
        }

        /// <summary>
        /// Internal exception
        /// </summary>
        public Exception Exception
        {
            get
            {
                return exception;
            }
        }

        /// <summary>
        /// Throws exception
        /// </summary>
        /// <param name="addition">Associated addition</param>
        /// <param name="exception">Internal exception</param>
        public static void Throw(AssociatedAddition addition,
            Exception exception)
        {
            if ((exception is DiagramException) | (exception is AssociatedException))
            {
                throw exception;
            }
            throw new AssociatedException(addition, exception);
        }

        /// <summary>
        /// Throws exception
        /// </summary>
        /// <param name="addition">Associated addition</param>
        /// <param name="message">Exception message</param>
        public static void Throw(AssociatedAddition addition, string message)
        {
            OwnException ex = new OwnException(message);
            Throw(addition, ex);
        }

        #endregion
    }
}
