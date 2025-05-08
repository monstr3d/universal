using Conversion3D.WebApplication.Server.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Conversion3D.WebApplication.Server.Classes
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
