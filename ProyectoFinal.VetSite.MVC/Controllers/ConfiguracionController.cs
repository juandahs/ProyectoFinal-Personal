using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class ConfiguracionController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Configuración";
            return View();
        }
    }
}
