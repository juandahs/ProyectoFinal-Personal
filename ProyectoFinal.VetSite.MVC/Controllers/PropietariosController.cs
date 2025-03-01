using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;


namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class PropietariosController( PropietarioServicio propietarioServicio
            , TipoIdentificacionServicio tipoIdentificacionServicio
            , UsuarioServicios usuarioServicios): Controller
    {
        private readonly PropietarioServicio _propietarioServicio = propietarioServicio;
        private readonly TipoIdentificacionServicio _tipoIdentificacionServicio = tipoIdentificacionServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;


        [HttpGet]
        public IActionResult Index() 
        {
            ViewBag.Title = "Gestion de propietarios";
            return View(_propietarioServicio.ObtenerTodos());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Propietario propietario)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "La información del propietario no es válida. Revísela y trate nuevamente.";
                return RedirectToAction("Index");
            }

            try
            {

                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var usuario = _usuarioServicios.ObtenerPorId(Guid.Parse(usuarioId!));
                
                propietario.UsuarioCreacionId = usuario!.UsuarioId;
                propietario.UsuarioModificacionId = usuario.UsuarioId;
                propietario.FechaCreacion = DateTime.Now;
                propietario.FechaModificacion= DateTime.Now;
                
                _propietarioServicio.Agregar(propietario);

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
                _propietarioServicio.Eliminar(id);
                TempData["MensajeExito"] = "El usuario ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el usuario: {e.Message}";
            }

            return RedirectToAction("Index");
        }


    }
}
