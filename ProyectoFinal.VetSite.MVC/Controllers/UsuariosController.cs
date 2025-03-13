using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class UsuariosController(UsuarioServicios usuarioServicios,
                              TipoIdentificacionServicio tipoIdentificacionServicio,
                              RolServicio rolServicio) : Controller
    {
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;
        private readonly TipoIdentificacionServicio _tipoIdentificacionServicio = tipoIdentificacionServicio;
        private readonly RolServicio _rolServicio = rolServicio;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestion de usuarios";
            var usuarios = _usuarioServicios.ObtenerTodos();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
            ViewData["Roles"] = _rolServicio.ObtenerTodos();
            return View();
        }

        [HttpPost]
        
        public IActionResult Crear(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "La información del usuario no es válida. Valide toda la información y trate nuevamente.";
                return RedirectToAction("Index");
            }

            try
            {
                if (_usuarioServicios.Existe(usuario.CorreoElectronico, usuario.NumeroIdentificacion))
                {
                    TempData["MensajeError"] = "Ya existe un usuario con el correo electrónico o el número de identificación indicado.";
                    return RedirectToAction("Index");
                }

                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                _usuarioServicios.Agregar(usuario, Guid.Parse(usuarioId!));
                TempData["MensajeExito"] = "Usuario creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de crear el usuario: {e.Message}";
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

            try
            {
                var usuario = _usuarioServicios.ObtenerPorId(id);
                if (usuario == null)
                {
                    TempData["MensajeError"] = "No se encontró un usuario con el identificador proporcionado.";
                    return RedirectToAction("Index");
                }

                ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
                ViewData["Roles"] = _rolServicio.ObtenerTodos();
                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]        
        public IActionResult Editar(Usuario usuario)
        {
            if (usuario == null)
            {
                TempData["MensajeError"] = "No se estableció un usuario válido.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                _usuarioServicios.Actualizar(usuario, Guid.Parse(usuarioModificacionId!));
                TempData["MensajeExito"] = "El usuario ha sido actualizado exitosamente.";
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
            if (_usuarioServicios.TotalUsuarios() == 1)
            {
                TempData["MensajeError"] = "No se puede eliminar el usuario ya que debe existir mínimo un usuario en el sistema.";
                return RedirectToAction("Index");
            }

            try
            {
                _usuarioServicios.Eliminar(id);
                TempData["MensajeExito"] = "El usuario ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el usuario: {e.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CambiarClave(Guid usuarioId, string claveActual, string nuevaClave, string nuevaClaveConfirmar)
        {
            if (Guid.Empty == usuarioId || string.IsNullOrWhiteSpace(claveActual) ||
                string.IsNullOrWhiteSpace(nuevaClave) || string.IsNullOrWhiteSpace(nuevaClaveConfirmar))
            {
                TempData["MensajeError"] = "Todos los campos son obligatorios.";
                return RedirectToAction("Index");
            }

            if (nuevaClave != nuevaClaveConfirmar)
            {
                TempData["MensajeError"] = "Las contraseñas no coinciden.";
                return RedirectToAction("Index");
            }

            var usuario = _usuarioServicios.ObtenerPorId(usuarioId);
            if (usuario == null)
            {
                TempData["MensajeError"] = "Usuario no encontrado.";
                return RedirectToAction("Index");
            }
            
            if (_usuarioServicios.EsValido(usuarioId, claveActual)) 
            {
                TempData["MensajeError"] = "La contraseña actual es incorrecta.";
                return RedirectToAction("Index");
            }

            _usuarioServicios.ActualizarClave(usuarioId, nuevaClave);          

            TempData["MensajeExito"] = "Contraseña cambiada correctamente.";
            return RedirectToAction("Index");
        }
    }
}
