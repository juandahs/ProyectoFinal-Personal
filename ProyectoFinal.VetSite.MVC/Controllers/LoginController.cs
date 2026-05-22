using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProyectoFinal.Servidor;


namespace ProyectoFinal.VetSite.MVC.Controllers
{
    public class LoginController(UsuarioServicios usuarioServicios) : Controller
    {
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;        
        
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string correoElectronico, string clave, bool rememberMe = false)
        {
            var usuario = _usuarioServicios.ObtenerPorCorreoElectronico(correoElectronico.ToLower());

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario no encontrado");
                return View("Index");
            }

            if (_usuarioServicios.IsLockedOut(usuario.UsuarioId))
            {
                ModelState.AddModelError(string.Empty, "Su cuenta está bloqueada temporalmente. Inténtelo más tarde.");
                return View("Index");
            }

            if (!_usuarioServicios.EsValido(usuario.UsuarioId, clave))
            {
                _usuarioServicios.IncrementFailedLogin(usuario.UsuarioId);
                ModelState.AddModelError(string.Empty, "La información del usuario no es válida.");
                return View("Index");
            }

            _usuarioServicios.ResetFailedLogin(usuario.UsuarioId);

            // Set authentication cookie
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, usuario.Nombre),
                new(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString())

            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
{
    IsPersistent = rememberMe,
    ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(7) : (DateTimeOffset?)null
};
await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

    }
}
