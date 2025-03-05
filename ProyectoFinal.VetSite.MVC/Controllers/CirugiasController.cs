using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class CirugiasController : Controller
    {
        private readonly CirugiaServicio _cirugiaServicio;
        private readonly TipoCirugiaServicio _tipoCirugiaServicio;
        private object _cirugiaServicios;

        public CirugiasController(CirugiaServicio cirugiaServicio, 
                                  TipoCirugiaServicio tipoCirugiaServicio)
        {
            _cirugiaServicio = cirugiaServicio;
            _tipoCirugiaServicio = tipoCirugiaServicio;
        }

        // Obtener todas las cirugías
        [HttpGet]

        public IActionResult Index()
        {
            ViewBag.Title = "Gestión de Cirugías";
            var cirugias = _cirugiaServicio.ObtenerTodos().ToList(); // ✅ Convertir a lista
            return View(cirugias);
        }


        // Vista para crear una nueva cirugía
        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["TiposCirugia"] = _tipoCirugiaServicio.ObtenerTodos();
            return View();
        }

        // Crear una cirugía
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cirugia cirugia)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "Los datos de la cirugía son inválidos.";
                return RedirectToAction("Crear");
            }

            try
            {
                //Validacion de si ya existe

                if (_cirugiaServicio.Existe(cirugia.FechaCreacion, cirugia.PacienteId, cirugia.TipoCirugiaId))
                {
                    TempData["MensajeError"] = "Ya existe una cirugía registrada con estos datos.";
                    return RedirectToAction("Crear");
                }

                //Si no existe, registra la cirugía
                _cirugiaServicio.Agregar(cirugia);
                TempData["MensajeExito"] = "Cirugía registrada exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Error al registrar la cirugía: {e.Message}";
            }

            return RedirectToAction("Index");   
        }
        
    
        //Eliminar

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Guid id)
        {
            if (_cirugiaServicio.TotalCirugias() == 1)
            {
                TempData["MensajeError"] = "No se puede eliminar la cirugia ya que debe existir mínimo un usuario en el sistema.";
                return RedirectToAction("Index");
            }

            try
            {
                _cirugiaServicio.Eliminar(id);
                TempData["MensajeExito"] = "Cirugía eliminada exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Error al eliminar la cirugía: {e.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar (Cirugia cirugia)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "Los datos son inválidos.";
                return RedirectToAction("Edit", new { id = cirugia.CirugiaId });
            }

            try
            {
                _cirugiaServicio.Actualizar(cirugia);
                TempData["MensajeExito"] = "Cirugía actualizada correctamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Error al actualizar la cirugía: {e.Message}";
            }

            return RedirectToAction("Index");
        }

    }
}
