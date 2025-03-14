using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace ProyectoFinal.Servidor
{
    public class CorreoServicio
    {
        private readonly string _emailOrigen;
        private readonly string _contrasena;

        public CorreoServicio(IConfiguration configuration)
        {
            _emailOrigen = configuration["EmailSettings:EmailOrigen"];
            _contrasena = configuration["EmailSettings:Contrasena"];
        }

        public void EnviarCorreo(string emailDestino, string asunto, string mensaje)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(_emailOrigen, emailDestino, asunto, mensaje)
                {
                    IsBodyHtml = true
                };

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential(_emailOrigen, _contrasena)
                };

                smtpClient.Send(mailMessage);
                smtpClient.Dispose();

              //  Console.WriteLine("Correo enviado correctamente."); //para comfirmar que si funciona
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
