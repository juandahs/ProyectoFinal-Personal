using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.Pages.Usuarios
{
    public class CreateModel(UsuarioServicios usuarioServicios): PageModel
    {
        private readonly UsuarioServicios _usuarioRepositorio = usuarioServicios;

        
        [BindProperty]
        public Usuario Usuario { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Usuario.UsuarioID = Guid.NewGuid();  // Asignar un nuevo ID
            Usuario.FechaCreacion = DateTime.Now;
            Usuario.UsuarioCreacionID = Guid.NewGuid();  // Asignar el ID del usuario creador

            _usuarioRepositorio.Agregar(Usuario);
            return RedirectToPage("./Index");
        }
    }
}
