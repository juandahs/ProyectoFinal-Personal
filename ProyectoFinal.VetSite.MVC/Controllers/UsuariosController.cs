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
                if (_usuarioServicios.Existe(usuario.CorreoElectronico))
                {
                    ModelState.AddModelError(string.Empty, "El usuario ya existe.");
                    return View(usuario);
                }
                
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

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            if(id == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "No se establecio un identificador de usuario");
                return RedirectToAction("Index");
            }

            try
            {
                var usuario = _usuarioServicios.ObtenerPorId(id);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "No se encontro un usuario con el identificador proporcionado.");
                    return RedirectToAction("Index");
                }

                ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
                ViewData["Roles"] = _rolServicio.ObtenerTodos();

                return View(usuario);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrio el siguiente error:\\n {e.Message}");
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "No se establecio un usuario válido.");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError(string.Empty, "No se establecio un modelo válido.");
                return RedirectToAction("Index");
            }

           
            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                _usuarioServicios.Actualizar(usuario, Guid.Parse(usuarioModificacionId!));
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, $"Ocurrio el siguiente error:\\n {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}
