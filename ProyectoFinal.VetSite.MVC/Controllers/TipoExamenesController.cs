using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class TipoExamenesController(
           TipoExamenServicio tipoExamenServicio
         , UsuarioServicios usuarioServicios) : Controller
    {

        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;
        private readonly TipoExamenServicio _tipoExamenServicio = tipoExamenServicio;


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestion de tipos de examenes";
            var tipoExamenes = _tipoExamenServicio.ObtenerTodos().ToList();
            return View(tipoExamenes);
        }

        [HttpGet] 
        public IActionResult Crear()
        {
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View();
        }
        
        [HttpPost]
        public IActionResult Crear(TipoExamen tipoExamen)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "El registro de la Tipo de examen no es válida. Valide toda la información y trate nuevamente.";
                return RedirectToAction("Index");
            }
            try
            {
                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                tipoExamen.FechaCreacion = DateTime.Now;
                tipoExamen.FechaModificacion = DateTime.Now;
                tipoExamen.UsuarioCreacionId = Guid.Parse(usuarioId!);
                tipoExamen.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _tipoExamenServicio.Agregar(tipoExamen);
                TempData["MensajeExito"] = "Tipo de examen creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de Registrar el tipo de examen: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            var tipoExamen = _tipoExamenServicio.ObtenerPorId(id);
            if (tipoExamen == null)
            {
                TempData["MensajeError"] = "El tipo de examen no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(tipoExamen);
        }

        [HttpPost]
        public IActionResult Editar(TipoExamen tipoExamen)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            if (_tipoExamenServicio.Existe(tipoExamen.TipoExamenId))
            {
                TempData["MensajeError"] = "No existe un tipo de examen con el identificador dado.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                tipoExamen.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                tipoExamen.FechaModificacion = DateTime.Now;

                _tipoExamenServicio.Actualizar(tipoExamen);
                TempData["MensajeExito"] = "El tipo de examen ha sido actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = $"Ocurrió un error: {ex.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Guid id)
        {

            if (_tipoExamenServicio.Existe(id))
            {
                TempData["MensajeError"] = "No existe un tipo de examen con el identificador dado.";
                return RedirectToAction("Index");
            }

            try
            {
                _tipoExamenServicio.Eliminar(id);
                TempData["MensajeExito"] = "El propietario ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el propietario: {e.Message}";
            }

            return RedirectToAction("Index");
        }

    }
}
