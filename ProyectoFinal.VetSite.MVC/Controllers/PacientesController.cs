using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class PacientesController(PacienteServicio pacienteServicio
        , PropietarioServicio propietarioServicio): Controller
    {
        private readonly PacienteServicio _pacienteServicio = pacienteServicio;
        private readonly PropietarioServicio _propietarioServicio = propietarioServicio;


        [HttpGet]
        public IActionResult Index() 
        {
            ViewBag.Title = "Gestion de pacientes.";
            return View(_pacienteServicio.ObtenerTodos());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["Propietarios"] = _propietarioServicio.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "La información del paciente no es válida. Revísela y trate nuevamente.";
                return RedirectToAction("Index");
            }

            try
            {
                
                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                

                paciente.UsuarioCreacionId = Guid.Parse(usuarioId!);
                paciente.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _pacienteServicio.Agregar(paciente);
                TempData["MensajeExito"] = "Paciente creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de crear el paciente: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Eliminar(Guid id)
        {   

            try
            {
                _pacienteServicio.Eliminar(id);
                TempData["MensajeExito"] = "El paciente ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el paciente: {e.Message}";
            }

            return RedirectToAction("Index");
        }



    }
}
