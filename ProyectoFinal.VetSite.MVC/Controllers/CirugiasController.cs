using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class CirugiasController (
        CirugiaServicio cirugiaServicio
      , TipoCirugiaServicio tipoCirugiaServicio
      , PacienteServicio pacienteServicio
      , UsuarioServicios usuarioServicios) : Controller
    {
        private readonly CirugiaServicio _cirugiaServicio = cirugiaServicio;
        private readonly TipoCirugiaServicio _tipoCirugiaServicio = tipoCirugiaServicio;
        private readonly PacienteServicio _pacienteServicio = pacienteServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestión de Cirugías";
            var cirugias = _cirugiaServicio.ObtenerTodos(); 
            return View(cirugias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            IEnumerable<TipoCirugia> tipoCirugias = _tipoCirugiaServicio.ObtenerTodos();
            if (!tipoCirugias.Any()) 
            {
                TempData["MensajeError"] = "Para crear una cirugía debe existir por lo menos un tipo de cirugía en el sistema.";
                return RedirectToAction("Index");
            }

            IEnumerable<Paciente> pacientes = _pacienteServicio.ObtenerTodos();
            if (!pacientes.Any())
            {
                TempData["MensajeError"] = "Para asignar una cirugía a un paciente debe existir por lo menos un paciente en el sistema.";
                return RedirectToAction("Index");
            }

            ViewData["TipoCirugias"] = tipoCirugias;
            ViewData["Pacientes"] = pacientes;
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cirugia cirugia)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "El registro de la cirugia no es válido. Valide toda la información y trate nuevamente.";
                return RedirectToAction("Index");
            }
            try
            {
                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                cirugia.FechaCreacion = DateTime.Now;
                cirugia.FechaModificacion = DateTime.Now;
                cirugia.UsuarioCreacionId = Guid.Parse(usuarioId!);
                cirugia.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _cirugiaServicio.Agregar(cirugia);
                TempData["MensajeExito"] = "Cirugia creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de Registrar la cirugía: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["MensajeError"] = "No se estableció un identificador de cirugia válido.";
                return RedirectToAction("Index");
            } 

            ViewData["TipoCirugias"] = _tipoCirugiaServicio.ObtenerTodos();
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View(_cirugiaServicio.ObtenerPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cirugia cirugia)
        {

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                cirugia.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                cirugia.FechaModificacion = DateTime.Now;

                _cirugiaServicio.Actualizar(cirugia);
                TempData["MensajeExito"] = "La cirugia ha sido actualizada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error: {ex.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Guid id)
        {
            try
            {
                _cirugiaServicio.Eliminar(id);
                TempData["MensajeExito"] = "La cirugia ha sido eliminada exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando la cirugia: {e.Message}";
            }

            return RedirectToAction("Index");
        }

    }
}
