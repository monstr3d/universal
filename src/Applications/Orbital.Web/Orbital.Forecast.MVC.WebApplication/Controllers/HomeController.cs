using FormulaEditor;
using FormulaEditor.Compiler;
using Microsoft.AspNetCore.Mvc;
using Orbital.Forecast.MVC.WebApplication.Models;
using System.Diagnostics;

namespace Orbital.Forecast.MVC.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            StaticExtensionFormulaEditorCompiler.Init();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ViewResult ForecastInput()
        {
            return View(new ForecastWeb());
        }

        [HttpPost]
        public ViewResult ForecastInput(ForecastWeb forecast)
        {
            var f = ForecastOutput.FromList(forecast.Values);
            return View("ForecastResult", f); 
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
