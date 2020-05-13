using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scada.WPF.UI.ErrorHandlers
{
    class MessageBoxErrorHandler : Interfaces.IErrorHandler
    {
        Window window;

        internal MessageBoxErrorHandler(Window window)
        {
            this.window = window;
        }

        void Interfaces.IErrorHandler.ShowError(Exception exception, object obj)
        {
            window.Dispatcher.InvokeAsync(() => { MessageBox.Show(window, exception.Message); });
        }

        void Interfaces.IErrorHandler.ShowMessage(string message, object obj)
        {
            window.Dispatcher.InvokeAsync(() => { MessageBox.Show(window, message); });
        }
    }
}
