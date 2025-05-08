using OnlineGameConverter.Server.Classes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineGameConverter.Server.Interfaces
{
    public interface IException
    {
        ExtendedException Exception { get; set; }

        ModelStateDictionary ModelState { get; set; }
    }

    public interface IExceptionSingleton : IException
    {
    }
}