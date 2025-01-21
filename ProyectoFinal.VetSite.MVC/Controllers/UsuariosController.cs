using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class UsuariosController(UsuarioServicios usuarioServicios
        ,TipoIdentificacionServicio tipoIdentificacionServicio
        , RolServicio rolServicio): Controller
    {
        private readonly UsuarioServicios _usuarioServicios =  usuarioServicios;
        private readonly TipoIdentificacionServicio _tipoIdentificacionServicio = tipoIdentificacionServicio;
        private readonly RolServicio _rolServicio = rolServicio;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestion de Usuarios";
            var usuarios = _usuarioServicios.ObtenerTodos();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Crear() {

            ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
            ViewData["Roles"] = _rolServicio.ObtenerTodos();
            return View();
        } 

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Por favor valide los campos.");
                return View(usuario); 
            }

            try
            {
                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                _usuarioServicios.Agregar(usuario, Guid.Parse(usuarioId!));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrio el siguiente error agregando el usuario. {e.Message}");
                return View(usuario); 
            }

            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult Eliminar(Guid id)
        {
            try
            {
                _usuarioServicios.Eliminar(id);

                TempData["MensajeExito"] = "El usuario ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                // Manejo de errores y mensajes al usuario
                TempData["MensajeError"] = $"Ocurrió un error eliminando el usuario: {e.Message}";
            }

            return RedirectToAction("Index");
        }

    }
}
