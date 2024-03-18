using Diagram.UI.Interfaces;

namespace Diagram.UI.ErrorHandlers
{
    /// <summary>
    /// Error handler which throws exceptoin once again
    /// This error handler is used for strict checking
    /// </summary>
    public class StrictErrorHandler : IErrorHandler
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly StrictErrorHandler Singleton = new StrictErrorHandler();

        #endregion

        #region Ctor

        private StrictErrorHandler()
        {
        }

        #endregion

        #region IErrorHandler Members

        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            throw exception;
        }


        void IErrorHandler.ShowMessage(string message, object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

  
    }
}