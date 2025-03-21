using System.Security.Claims;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Entidades;
using ProyectoFinal.Servidor;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    public class CitasController(CitaServicio citaServicio, 
                                 PacienteServicio pacienteServicio,
                                 CorreoServicio correoServicio, 
                                 UsuarioServicios usuarioServicios) : Controller
    {
        private readonly CitaServicio _citaServicio = citaServicio;
        private readonly PacienteServicio _pacienteServicio = pacienteServicio;
        private readonly CorreoServicio _correoServicio = correoServicio;
        private readonly UsuarioServicios _usuarioServicios = usuarioServicios;
        public string _plantillaPropietario = """ 

         <!DOCTYPE html>
      <html lang="en" xmlns="http://www.w3.org/1999/xhtml">
      <head>
          <meta charset="UTF-8">
          <title>Confirmación de Cita - Clínica Veterinaria</title>
          <style>
              body {
                  font-family: Arial, sans-serif;
                  background-color: #ffffff;
                  margin: 0;
                  padding: 0;
                  text-align: center;
                  color: black;
              }

              .container {
                  width: 100%;
                  max-width: 600px;
                  margin: auto;
                  border: 1px solid #ddd;
                  border-radius: 8px;
                  overflow: hidden;
                  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
                  color: black;
                  text-align: center;
              }

              .header {
                  background-color: #00171f;
                  padding: 20px;
                  color: white;
              }

                  .header img {
                      max-width: 150px;
                  }

              .content {
                  padding: 20px;
                  font-size: 15px;
              }

                  .content h2 {
                      color: #007ea7;
                  }

              .details-table {
                  width: 90%;
                  margin: auto;
                  border-collapse: collapse;
                  color: black;
                  text-align: center; /* Centra el texto en la tabla */
              }

                  .details-table td {
                      padding: 12px; /* Más espacio para mayor legibilidad */
                      border-bottom: 1px solid #ddd;
                      color: black;
                  }

                      .details-table td:first-child {
                          font-weight: bold;
                          width: 40%;
                      }

              .footer {
                  background-color: #f8f8f8;
                  padding: 7px;
                  font-size: 10px;
                  color: #555;
                  height: 60px;
              }
          </style>
      </head>
      <body>
          <div class="container">
              <div class="header">
                  <img src="LOGO_URL" alt="Clínica Veterinaria">
              </div>
              <div class="content">
                  <h2>¡Tu cita está programada!</h2>
                  <table class="details-table">
                      <tr>
                          <td>Propietario:</td>
                          <td>{0}</td>
                      </tr>
                      <tr>
                          <td>Mascota:</td>
                          <td>{1}</td>
                      </tr>
                      <tr>
                          <td>Motivo:</td>
                          <td>{2}</td>
                      </tr>
                      <tr>
                          <td>Fecha:</td>
                          <td>{3}</td>
                      </tr>
                      <tr>
                          <td>Hora:</td>
                          <td>{4}</td>
                      </tr>
                  </table>
              </div>
              <div class="footer">
                  <p>Gracias por confiar en nuestra clínica veterinaria.<br />
                  Para mayor información, contáctanos: notificacionesvetsite@gmail.com</p>
              </div>
          </div>
      </body>
      </html>     
    
      """;





        [HttpGet]
        public IActionResult Index(int? month, int? year)
        {
            // Determina el mes y año a mostrar
            var today = DateTime.Today;
            var selectedMonth = month ?? today.Month;
            var selectedYear = year ?? today.Year;

            // Obtiene las citas
            var citas = _citaServicio.ObtenerTodos();

            // Pasa a la vista
            ViewBag.Month = selectedMonth;
            ViewBag.Year = selectedYear;
            return View(citas);
        }

        [HttpGet]
        public IActionResult Crear() 
        {

            IEnumerable<Paciente> pacientes = _pacienteServicio.ObtenerTodos();
            if (!pacientes.Any())
            {
                TempData["MensajeError"] = "Para asignar una cita a un paciente debe existir por lo menos un paciente en el sistema.";
                return RedirectToAction("Index");
            }

            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Cita cita)
        {
            if (cita.Fecha.Date < DateTime.Now.Date) //si la fecha es menor que la fecha actual, muestre un menasje de rror
            {
                TempData["MensajeError"] = "No puedes agendar una cita en un día que ya pasó.";
                return RedirectToAction("Crear");
            }

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "La información de la cita no es válida. Revísela y trate nuevamente.";
                return RedirectToAction("Index");
            }
            try
            {

                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                cita.Estado = CitaEstado.Programada;
                cita.FechaCreacion = DateTime.Now;
                cita.FechaModificacion = DateTime.Now;
                cita.UsuarioCreacionId = Guid.Parse(usuarioId!);
                cita.UsuarioModificacionId = Guid.Parse(usuarioId!);

                _citaServicio.Insertar(cita);
                
                //Valores para enviar correo
                var asunto = "Cita programada!";
                var propietario = _pacienteServicio.ObtenerPorId(cita.PacienteId).Propietario.Nombre.ToString();
                var paciente = _pacienteServicio.ObtenerPorId(cita.PacienteId).Nombre.ToString();
                var motivo = cita.Motivo;
                var fecha = cita.Fecha.ToString("dd/MM/yyyy");
                var hora = cita.Fecha.ToString("hh:mm tt");

                var mensaje = _plantillaPropietario
                    .Replace("{0}", propietario)
                    .Replace("{1}", paciente)
                    .Replace("{2}", motivo)
                    .Replace("{3}", fecha)
                    .Replace("{4}", hora);

                _correoServicio.EnviarCorreo(_pacienteServicio.ObtenerPorId(cita.PacienteId).Propietario.CorreoElectronico,asunto, mensaje);
                TempData["MensajeExito"] = "Cita creada exitosamente.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error tratando de crear la cita: {e.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["MensajeError"] = "No se estableció un identificador de cita válido.";
                return RedirectToAction("Index");
            }
            ViewData["Pacientes"] = _pacienteServicio.ObtenerTodos();
            ViewData["Usuarios"] = _usuarioServicios.ObtenerTodos();
            return View(_citaServicio.ObtenerPorId(id));
        }

        [HttpPost]
        public IActionResult Editar(Cita cita)
        {

            if (!ModelState.IsValid)
            {
                TempData["MensajeError"] = "No se estableció un modelo válido.";
                return RedirectToAction("Index");
            }

            if (!_citaServicio.Existe(cita.CitaId))
            {
                TempData["MensajeError"] = "No se existe el tipo de cita indicado.";
                return RedirectToAction("Index");
            }

            try
            {
                var usuarioModificacionId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                cita.UsuarioModificacionId = Guid.Parse(usuarioModificacionId!);
                cita.FechaModificacion = DateTime.Now;

                _citaServicio.Actualizar(cita);
                TempData["MensajeExito"] = "La cita ha sido actualizada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = $"Ocurrió el siguiente error: {ex.Message}";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CancelarEstado(Guid Id, Cita cita)
        {
            try
            {
                if (!_citaServicio.Existe(Id))
                {
                    TempData["MensajeError"] = "No existe el usuario con el identificador dado.";
                    return RedirectToAction("Index");
                }

                var usuarioId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


                _citaServicio.EditarEstado(Id, CitaEstado.Cancelada, Guid.Parse(usuarioId!));
               
                if(CitaEstado.Cancelada == CitaEstado.Cancelada)
                {
                    TempData["MensajeError"] = "La cita ya esta cancelada.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensajeExito"] = "La cita ha sido cancelada exitosamente.";

                }


            }
            catch (Exception e)
            {
                TempData["MensajeError"] = $"Ocurrió un error al cancelar la cita: {e.Message}";
            }

            return RedirectToAction("Index");
        }


    }
}
