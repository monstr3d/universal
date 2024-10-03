using System;
using System.Collections.Generic;
using System.Text;

namespace TestCategory
{
    /// <summary>
    /// Test exception
    /// </summary>
    public class TestException : Exception
    {

        #region Fields

        private string objectName;

        private object objectId;

        private Exception exception;


        #endregion

        #region Ctor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectName">Object name</param>
        /// <param name="objectId">Object id</param>
        /// <param name="exception">Inner exception</param>
        public TestException(string objectName, object objectId, Exception exception)
        {
            this.objectName = objectName;
            this.objectId = objectId;
            this.exception = exception;
        }

        #endregion

        #region Members

        /// <summary>
        /// Object name
        /// </summary>
        public string ObjectName
        {
            get
            {
                return objectName;
            }
        }

        /// <summary>
        /// Object id
        /// </summary>
        public object ObjectId
        {
            get
            {
                return objectId;
            }
        }

        /// <summary>
        /// Internal exception
        /// </summary>
        public Exception Exception
        {
            get
            {
                if (exception is Diagram.UI.DiagramException)
                {
                    Diagram.UI.DiagramException ex = exception as Diagram.UI.DiagramException;
                    return ex.Exception;
                }
                return exception;
            }
        }

        /// <summary>
        /// Gets root exception
        /// </summary>
        /// <param name="e">Outer exception</param>
        /// <returns>Root exception</returns>
        public static Exception GetRoot(Exception e)
        {
            if (e.InnerException == null)
            {
                return e;
            }
            return GetRoot(e.InnerException);
        }


        #endregion
    }
}
