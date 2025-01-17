using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ErrorHandler;

namespace Scada.Wpf.Common.ErrorHandlers
{
    class MessageBoxErrorHandler : IErrorHandler
    {
        Window window;

        internal MessageBoxErrorHandler(Window window)
        {
            this.window = window;
        }

        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            window.Dispatcher.InvokeAsync(() => { MessageBox.Show(window, exception.Message); });
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
            window.Dispatcher.InvokeAsync(() => { MessageBox.Show(window, message); });
        }
    }
}
