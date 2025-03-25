using System;
using System.IO;

using ErrorHandler;

namespace Diagram.UI.ErrorHandlers
{
    /// <summary>
    /// Error handler for text writer
    /// </summary>
    public class TextWriterErrorHandler : IExceptionHandler, IDisposable
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

        void IExceptionHandler.HandleException<T>(T e, params object[]? obj)
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

        void IExceptionHandler.Log(string message, params object[]? o)
        {
            writer.WriteLine(message);
        }

 
        #endregion
    }
}
