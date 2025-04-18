﻿using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<IActionResult> Login(string correoElectronico, string clave)
        {
            var usuario = _usuarioServicios.ObtenerPorCorreoElectronico(correoElectronico.ToLower());

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "usuario no encontrado");
                return View("Index");
            }

            if (!_usuarioServicios.EsValido(usuario.UsuarioId, clave))
            {
                ModelState.AddModelError(string.Empty, "La información del usuario no es valida.");
                return View("Index");
            }

            // Set authentication cookie
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, usuario.Nombre),
                new(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString())

            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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
