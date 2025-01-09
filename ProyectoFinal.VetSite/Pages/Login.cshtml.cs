using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.VetSite.Resources;

namespace ProyectoFinal.VetSite.Pages
{
    public class LoginModel(UsuarioServicios usuarioServicios) : PageModel
    {
        private readonly UsuarioServicios _usuarioServicio = usuarioServicios;
               

        [BindProperty]
        public Credenciales? Credenciales { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Usuario? usuario = _usuarioServicio.ObtenerPorNombre(Credenciales.Nombre);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, LoginResource.ErrorUsuarioClave);
                return Page();
            }

            if (_usuarioServicio.EsValido(usuario.UsuarioID, Credenciales.Clave))
            {
                HttpContext.Session.SetString("UsuarioID", usuario.UsuarioID.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);

                return RedirectToPage("/Index");
            }
            
            ModelState.AddModelError("", LoginResource.ErrorUsuarioClave);
            return Page();
            
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();

            return RedirectToPage("/Login");
        }

    }
}
