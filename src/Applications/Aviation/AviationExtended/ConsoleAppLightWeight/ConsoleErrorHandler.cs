using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLightWeight
{
    class ConsoleErrorHandler : IErrorHandler
    {
        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            int i = 0;
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
            int i = 0;
        }
    }
}
