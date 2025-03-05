﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;


namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class PropietariosController( PropietarioServicio propietarioServicio
            , TipoIdentificacionServicio tipoIdentificacionServicio
            , UsuarioServicios usuarioServicios): Controller
    {
        private readonly PropietarioServicio _propietarioServicio = propietarioServicio;
        private readonly TipoIdentificacionServicio _tipoIdentificacionServicio = tipoIdentificacionServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;


        [HttpGet]
        public IActionResult Index() 
        {
            ViewBag.Title = "Gestion de propietarios";
            return View(_propietarioServicio.ObtenerTodos());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Propietario propietario)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "La información del propietario no es válida. Revísela y trate nuevamente.";
                return RedirectToAction("Index");
            }

            try
            {

                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                                
                propietario.UsuarioCreacionId = Guid.Parse(usuarioId!);
                propietario.UsuarioModificacionId = Guid.Parse(usuarioId!);
                propietario.FechaCreacion = DateTime.Now;
                propietario.FechaModificacion= DateTime.Now;
                
                _propietarioServicio.Agregar(propietario);

                TempData["MensajeExito"] = "Propietario creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de crear el propietario: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            
            ViewData["TiposIdentificacion"] = _tipoIdentificacionServicio.ObtenerTodos();
            return View(_propietarioServicio.ObtenerPorId(id));
        }

        [HttpPost]
        public IActionResult Editar(Propietario propietario)
        {

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                propietario.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                propietario.FechaModificacion = DateTime.Now;

                _propietarioServicio.Actualizar(propietario);
                TempData["MensajeExito"] = "El propietario ha sido actualizado exitosamente.";
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
            try
            {
                _propietarioServicio.Eliminar(id);
                TempData["MensajeExito"] = "El propietario ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando el propietario: {e.Message}";
            }

            return RedirectToAction("Index");
        }


    }
}
