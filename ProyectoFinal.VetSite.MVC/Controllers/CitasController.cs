using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    public class CitasController(CitaServicio citaServicio, PacienteServicio pacienteServicio) : Controller
    {
        private readonly CitaServicio _citaServicio = citaServicio;
        private readonly PacienteServicio _pacienteServicio = pacienteServicio;



        [HttpGet]
        public IActionResult Index(int? month, int? year)
        {
            // Determina el mes y año a mostrar
            var today = DateTime.Today;
            var selectedMonth = month ?? today.Month;
            var selectedYear = year ?? today.Year;

            // Obtiene las citas
            var citas = _citaServicio.ObtenerTodos();

            // Pasa a la vista
            ViewBag.Month = selectedMonth;
            ViewBag.Year = selectedYear;
            return View(citas);
        }

        [HttpGet]
        public IActionResult Crear() 
        {
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            return View();
        }
    }
}
