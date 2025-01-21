using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
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
        public IActionResult Create() {

            ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
            ViewData["Roles"] = _rolServicio.ObtenerTodos();
            return View();
        } 

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Por favor valide los campos.");
                return View(usuario); 
            }

            try
            {
                _usuarioServicios.Agregar(usuario);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrio el siguiente error agregando el usuario. {e.Message}");
                return View(usuario); 
            }

            return RedirectToAction("Index"); 
        }
    }
}
