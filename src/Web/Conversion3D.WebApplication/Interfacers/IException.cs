using Conversion3D.WebApplication.Classes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Conversion3D.WebApplication.Interfacers
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