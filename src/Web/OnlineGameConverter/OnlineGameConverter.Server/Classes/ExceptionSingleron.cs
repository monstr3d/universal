using OnlineGameConverter.Server.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineGameConverter.Server.Classes
{
    public class ExceptionSingleton : IExceptionSingleton
    {
        public ExceptionSingleton()
        {

        }

        ExtendedException IException.Exception { get; set; }

        ModelStateDictionary IException.ModelState { get ; set; }
    }
}
