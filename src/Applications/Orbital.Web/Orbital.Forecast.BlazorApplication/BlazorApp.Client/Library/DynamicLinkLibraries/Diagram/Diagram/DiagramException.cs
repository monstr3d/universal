using System;
using System.Collections.Generic;
using System.Text;
using Diagram.UI.Labels;


namespace Diagram.UI
{
    /// <summary>
    /// The exception of diagram object
    /// </summary>
    public class DiagramException : Exception
    {
        /// <summary>
        /// The component
        /// </summary>
        private INamedComponent comp;

        /// <summary>
        /// Exception
        /// </summary>
        private Exception exception;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exception">Inner exception</param>
        /// <param name="comp">Associated component</param>
         public DiagramException(Exception exception, INamedComponent comp)
            : base(exception.Message)
        {
            this.comp = comp;
            this.exception = exception;
        }

        /// <summary>
        /// The component
        /// </summary>
        public INamedComponent Component
        {
            get
            {
                return comp;
            }
        }

        /// <summary>
        /// Linked exception
        /// </summary>
        public Exception Exception
        {
            get
            {
                return exception;
            }
        }
    }
}
