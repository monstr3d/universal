using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ErrorHandler;

namespace Scada.Wpf.Common.ErrorHandlers
{
    class MessageBoxErrorHandler : IExceptionHandler
    {
        Window window;

        internal MessageBoxErrorHandler(Window window)
        {
            this.window = window;
        }

        void IExceptionHandler.HandleException<T>(T exception, object[] obj)
        {
            window.Dispatcher.InvokeAsync(() => { MessageBox.Show(window, exception.Message); });
        }

        void IExceptionHandler.Log(string message, object[] obj)
        {
            window.Dispatcher.InvokeAsync(() => { MessageBox.Show(window, message); });
        }
    }
}
