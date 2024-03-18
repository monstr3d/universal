
namespace Scada.Desktop
{
    class ErrorHandlerWrapper : Diagram.UI.Interfaces.IErrorHandler
    {
        Interfaces.IErrorHandler handler;

        internal ErrorHandlerWrapper(Interfaces.IErrorHandler handler)
        {
            this.handler = handler;
        }

        void Diagram.UI.Interfaces.IErrorHandler.ShowError(Exception exception, object obj)
        {
            handler.ShowError(exception, obj);
        }

        void Diagram.UI.Interfaces.IErrorHandler.ShowMessage(string message, object obj)
        {
            handler.ShowMessage(message, obj);
        }
    }
}
