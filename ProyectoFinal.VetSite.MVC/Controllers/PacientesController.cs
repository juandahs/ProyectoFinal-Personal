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
            IEnumerable<Propietario> propietarios = _propietarioServicio.ObtenerTodos();
            
            if (!propietarios.Any()) 
            {
                TempData["MensajeError"] = "Para crear un paciente debe existir por lo menos un propietario creado en el sistema.";
                return RedirectToAction("Index");
            }

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

                paciente.FechaCreacion = DateTime.Now;
                paciente.FechaModificacion = DateTime.Now;
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

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["MensajeError"] = "No se estableció un identificador de pacientte válido.";
                return RedirectToAction("Index");
            }

            return View(_pacienteServicio.ObtenerPorId(id));
        }

        [HttpPost]
        
        public IActionResult Editar(Paciente paciente)
        {

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                paciente.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                paciente.FechaModificacion = DateTime.Now;

                _pacienteServicio.Actualizar(paciente);
                TempData["MensajeExito"] = "El paciente ha sido actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error: {ex.Message}";
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
