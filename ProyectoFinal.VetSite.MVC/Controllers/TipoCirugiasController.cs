using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class TipoCirugiasController(TipoCirugiaServicio tipoCirugiaServicio, UsuarioServicios usuarioServicios) : Controller
    {
        private readonly TipoCirugiaServicio _tipoCirugiaServicio = tipoCirugiaServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestión de Tipos de Cirugía";
            var tiposCirugia = _tipoCirugiaServicio.ObtenerTodos();
            return View(tiposCirugia);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Crear(TipoCirugia tipoCirugia)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "El registro del tipo de cirugía no es válido. Valide toda la información y trate nuevamente.";
                return RedirectToAction("Index");
            }
            try
            {
                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                tipoCirugia.FechaCreacion = DateTime.Now;
                tipoCirugia.FechaModificacion = DateTime.Now;
                tipoCirugia.UsuarioCreacionId = Guid.Parse(usuarioId!);
                tipoCirugia.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _tipoCirugiaServicio.Agregar(tipoCirugia);
                TempData["MensajeExito"] = "Tipo de cirugía creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error registrando el tipo de cirugía: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            var tipoCirugia = _tipoCirugiaServicio.ObtenerPorId(id);
            if (tipoCirugia == null)
            {
                TempData["MensajeError"] = "El tipo de cirugía no fue encontrado.";
                return RedirectToAction("Index");
            }
            return View(tipoCirugia);
        }

        [HttpPost]
        
        public IActionResult Editar(TipoCirugia tipoCirugia)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                tipoCirugia.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                tipoCirugia.FechaModificacion = DateTime.Now;

                _tipoCirugiaServicio.Actualizar(tipoCirugia);
                TempData["MensajeExito"] = "El tipo de cirugía ha sido actualizado exitosamente.";
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
            try
            {
                _tipoCirugiaServicio.Eliminar(id);
                TempData["MensajeExito"] = "El tipo de cirugía ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el tipo de cirugía: {e.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
