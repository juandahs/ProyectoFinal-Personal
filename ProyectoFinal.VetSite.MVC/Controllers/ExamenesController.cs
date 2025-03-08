using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class ExamenesController(
           ExamenServicio examenServicio
         , TipoExamenServicio tipoExamenServicio
         , PacienteServicio pacienteServicio
         , UsuarioServicios usuarioServicios) : Controller
    {
        private readonly PacienteServicio _pacienteServicio = pacienteServicio;
        private readonly ExamenServicio _examenServicio = examenServicio;
        private readonly TipoExamenServicio _tipoExamenServicio = tipoExamenServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestion de pacientes.";
            return View(_examenServicio.ObtenerTodos());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["TipoExamenes"] = _tipoExamenServicio.ObtenerTodos();
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Examen examen)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "La información del examen no es válida. Revísela y trate nuevamente.";
                return RedirectToAction("Index");
            }

            try
            {

                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                examen.FechaCreacion = DateTime.Now;
                examen.FechaModificacion = DateTime.Now;
                examen.UsuarioCreacionId = Guid.Parse(usuarioId!);
                examen.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _examenServicio.Agregar(examen);
                TempData["MensajeExito"] = "Examen creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de crear el examen: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["MensajeError"] = "No se estableció un identificador de usuario.";
                return RedirectToAction("Index");
            }

            ViewData["TipoExamenes"] = _tipoExamenServicio.ObtenerTodos();
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();

            return View(_examenServicio.ObtenerPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Examen examen)
        {

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                examen.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                examen.FechaModificacion = DateTime.Now;

                _examenServicio.Actualizar(examen);
                TempData["MensajeExito"] = "El examen ha sido actualizado exitosamente.";
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
                _examenServicio.Eliminar(id);
                TempData["MensajeExito"] = "El examen ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el examen: {e.Message}";
            }

            return RedirectToAction("Index");
        }

    }
}
