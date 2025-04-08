using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProyectoFinal.VetSite.MVC.Models;
using System.Diagnostics;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
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
