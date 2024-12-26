using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.Pages.Usuarios
{
    public class IndexModel(UsuarioServicios usuarioServicios) : PageModel
    {
        private readonly UsuarioServicios _usuarioServicio = usuarioServicios;

        public List<Usuario> Usuarios { get; set; }

        public void OnGet()
        {
            Usuarios = _usuarioServicio.ObtenerTodos();
        }
    }
}
