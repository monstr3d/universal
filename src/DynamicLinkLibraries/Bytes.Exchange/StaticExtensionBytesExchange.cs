using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionBytesExchange
    {
        #region Ctor

       static StaticExtensionBytesExchange()
        {
            ErrorHandler = new EmptyError();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Error handler
        /// </summary>
        public static Bytes.Exchange.Interfaces.IErrorHandler ErrorHandler
        { get; set; }

        /// <summary>
        /// Shows an error
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="exception">The exception</param>
        public static void ShowError(this object sender, Exception exception)
        {
            ErrorHandler.ShowError(sender, exception);
        }

        /// <summary>
        /// Creates binding
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Binding</returns>
        public static System.ServiceModel.Channels.Binding ToBinding(this RemoteType type)
        {
            switch (type)
            {
                case RemoteType.Ipc:
                    return new System.ServiceModel.NetNamedPipeBinding();
                case RemoteType.Tcp:
                    return new System.ServiceModel.NetTcpBinding();
                case RemoteType.Http:
                    return new System.ServiceModel.WSDualHttpBinding();
                default:
                    break;
            }
            return null;
        }

        #endregion

        #region Classes

        class EmptyError : Bytes.Exchange.Interfaces.IErrorHandler
        {

            void Interfaces.IErrorHandler.ShowError(object sender, Exception exception)
            {
               
            }
        }

        #endregion
    }
}
