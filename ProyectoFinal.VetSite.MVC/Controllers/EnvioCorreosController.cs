using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Servidor;
using ProyectoFinal.VetSite.MVC.Models;

namespace ProyectoFinal.VetSite.MVC.Controllers
{
    public class EnvioCorreosController(EnvioCorreoServicio envioCorreoServicio) : Controller
    {
        private readonly EnvioCorreoServicio _envioCorreoServicio = envioCorreoServicio;
        // GET: EnvioCorreosController
        public ActionResult Index()
        {
            ViewBag.Title = "Enviar Correo";
            return View("Index");
        }

        public IActionResult EnviarCorreo(EnvioCorreoModel model, EnvioCorreoServicio envio)
        {
            if (ModelState.IsValid)
            {
                string EmailDestino = "friyitas@gmail.com"; // Cambia esto según sea necesario

                MailMessage mailMessage = new MailMessage(envio._emailOrigen, EmailDestino, model.Asunto, model.Mensaje);
                mailMessage.IsBodyHtml = true;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(envio._emailOrigen, envio._contrasena);

                    smtpClient.SendMailAsync(mailMessage);

                }

                ViewBag.Mensaje = "Correo enviado correctamente.";
            }

            return View();
        }

    }
}
