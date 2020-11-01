using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using TestCategory.Interfaces;

namespace TestCategory
{
    /// <summary>
    /// Standard writer of exceptions
    /// </summary>
    public class StandardTextExceptionWriter : IExceptionWriter
    {
        #region Fields

        TextWriter writer;
        DateTime time;
        bool writeHeaders;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="writer">Writer</param>
        /// <param name="writeHeaders">The "write headers" sign</param>
        public StandardTextExceptionWriter(TextWriter writer, bool writeHeaders)
        {
            this.writer = writer;
            this.writeHeaders = writeHeaders;
        }

        #endregion


        #region IExceptionWriter Members

        /// <summary>
        /// Writes exception
        /// </summary>
        /// <param name="e">Exception to write</param>
        public virtual void Write(TestException e)
        {
            writer.WriteLine(e.ObjectName + "");
            writer.WriteLine(e.ObjectId + "");
            Exception ex = e.Exception;
            if (ex is Diagram.UI.DiagramException)
            {
                Diagram.UI.DiagramException de = ex as Diagram.UI.DiagramException;
                ex = de.Exception;
            }
            writer.WriteLine(ex.Message);
            writer.Write(ex.StackTrace);
            writer.WriteLine();
            writer.WriteLine("+++++++++++++");
            writer.WriteLine();
            writer.Flush();
        }

        /// <summary>
        /// Writes header of object
        /// </summary>
        /// <param name="o">The object</param>
        public virtual void WriteHeader(object o)
        {
            if (time == null)
            {
                time = DateTime.Now;
            }
            else
            {
                DateTime t = DateTime.Now;
                TimeSpan ts = t - time;
                writer.WriteLine(ts.Minutes);
                time = t;
            }
            if (writeHeaders)
            {
                writer.WriteLine(o + "");
                writer.Flush();
            }
        }


        #endregion
    }
}
