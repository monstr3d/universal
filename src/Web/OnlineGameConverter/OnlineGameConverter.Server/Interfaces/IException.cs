using Microsoft.AspNetCore.Mvc.ModelBinding;

using OnlineGameConverter.Server.Classes;


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