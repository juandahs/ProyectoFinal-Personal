using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.Pages.Usuarios
{
    public class EditModel(UsuarioServicios usuarioServicios): PageModel
    {
        private readonly UsuarioServicios _usuarioRepositorio = usuarioServicios;

        [BindProperty]
        public Usuario Usuario { get; set; }

        public IActionResult OnGet(Guid id)
        {
            Usuario = _usuarioRepositorio.ObtenerPorId(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Usuario.FechaModificacion = DateTime.Now;
            Usuario.UsuarioModificacionID = Guid.NewGuid();  

            _usuarioRepositorio.Actualizar(Usuario);
            return RedirectToPage("./Index");
        }
    }
}
