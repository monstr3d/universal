using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Diagram.UI.Interfaces;
using CategoryTheory;

namespace Diagram.UI.ErrorHandlers
{
    /// <summary>
    /// Error handler for text writer
    /// </summary>
    public class TextWriterErrorHandler : IErrorHandler, IDisposable
    {
        #region Fields

        TextWriter writer;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="writer">Text writer</param>
        public TextWriterErrorHandler(TextWriter writer)
        {
            this.writer = writer;

        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            try
            {
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region IErrorHandler  Members

        void IErrorHandler.ShowError(Exception e, object o)
        {
           /* if (level == 0)
            {
                string message = e.Message;
                string url = null;
                if (e is INamedObject)
                {
                    INamedObject n = e as INamedObject;
                    url = n.Name;
                }
                writer.WriteLine(e.StackTrace);
            }
            else
            {
                writer.WriteLine("WARNING: TYPE:" + e.GetType().Name + " MESSAGE: " + e.Message);
            }*/
       }

        void IErrorHandler.ShowMessage(string message, object o)
        {
            writer.WriteLine(message);
        }

 
        #endregion
    }
}
