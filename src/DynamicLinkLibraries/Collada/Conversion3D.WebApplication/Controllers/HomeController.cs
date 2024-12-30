using Conversion3D.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Conversion3D.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var a = View();
            return a;
        }

        public IActionResult BufferedDoubleFileUploadDb()
        {
            var a = View();
            return a;
        }

        public IActionResult BufferedSingleFileUploadPhysical()
        {
            var a = View();
            return a;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
