﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;
using System.Security.Claims;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    [Authorize]
    public class VacunasController(
           VacunaServicio vacunaServicio
         , PacienteServicio pacienteServicio
         , UsuarioServicios usuarioServicios) : Controller
    {
        private readonly PacienteServicio _pacienteServicio = pacienteServicio;
        private readonly VacunaServicio _vacunaServicio = vacunaServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Gestion de vacunas";
            var vacunas = _vacunaServicio.ObtenerTodos();
            return View(vacunas);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View();
        }

        [HttpPost]
        
        public IActionResult Crear(Vacuna vacuna)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "El registro de la vacuna no es válida. Valide toda la información y trate nuevamente.";
                return RedirectToAction("Index");
            }
            try
            {
                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                vacuna.FechaCreacion = DateTime.Now;
                vacuna.FechaModificacion = DateTime.Now;
                vacuna.UsuarioCreacionId = Guid.Parse(usuarioId!);
                vacuna.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _vacunaServicio.Agregar(vacuna);
                TempData["MensajeExito"] = "Vacuna creado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de Registrar la vacuna: {e.Message}";
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

            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();

            return View(_vacunaServicio.ObtenerPorId(id));
        }

        [HttpPost]
        
        public IActionResult Editar(Vacuna vacuna)
        {

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            if (!_vacunaServicio.Existe(vacuna.VacunaId))
            {
                TempData["MensajeError"] = "No existe la vacuna con el identificador dado.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                vacuna.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                vacuna.FechaModificacion = DateTime.Now;

                _vacunaServicio.Actualizar(vacuna);
                TempData["MensajeExito"] = "El vacuna ha sido actualizado exitosamente.";
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

            if (!_vacunaServicio.Existe(id))
            {
                TempData["MensajeError"] = "No existe la vacuna con el identificador dado.";
                return RedirectToAction("Index");
            }

            try
            {
                _vacunaServicio.Eliminar(id);
                TempData["MensajeExito"] = "El propietario ha sido eliminado exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error eliminando la vacuna: {e.Message}";
            }

            return RedirectToAction("Index");
        }


    }
}
