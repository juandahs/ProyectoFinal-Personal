using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using ProyectoFinal.Repositorio;
using System.Security.Claims;
using NuGet.Protocol.Core.Types;



namespace ProyectoFinal.VetSite.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _contexto;
        public LoginController(Contexto contexto) => _contexto = contexto;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string nombre, string clave)
        {
            var usuario = await _contexto.Usuarios
                .FirstOrDefaultAsync(u => u.Nombre == nombre);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "LoginResource.ErrorUsuarioClave");
                return View("Index");
            }

            if (!await _contexto.ValidarClaveAsync(usuario.UsuarioID, clave))
            {
                ModelState.AddModelError(string.Empty, "Usuario no encontrado");
                return View("Index");
            }

            // Set authentication cookie
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, usuario.Nombre)
            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

    }
}
