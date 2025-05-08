using Conversion3D.WebApplication.Server.Classes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Conversion3D.WebApplication.Server.Interfaces
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