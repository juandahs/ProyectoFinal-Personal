using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System;
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



        // Obtener todas las cirugías
        [HttpGet]

        public IActionResult Index()
        {
            ViewBag.Title = "Gestión de Cirugías";
            var cirugias = _cirugiaServicio.ObtenerTodos().ToList(); 
            return View(cirugias);
        }


        // Vista para crear una nueva cirugía
        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["TipoCirugias"] = _tipoCirugiaServicio.ObtenerTodos().ToList(); 
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos().ToList();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos().ToList();

            return View();
        }


        // Crear una cirugía
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cirugia cirugia)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "El registro de la cirugia no es válido. Revíselo y trate nuevamente.";
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


        //Eliminar
        [HttpPost]
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

        //Editar

        [HttpGet]
        public IActionResult Editar(Guid id)
        {

            ViewData["TipoCirugias"] = _tipoCirugiaServicio.ObtenerTodos();
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View(_cirugiaServicio.ObtenerPorId(id));
        }

        [HttpPost]
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


    }
}
