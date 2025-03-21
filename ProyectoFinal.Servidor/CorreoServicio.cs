using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ProyectoFinal.Entidades;

namespace ProyectoFinal.Servidor
{
    public class CorreoServicio(IConfiguration configuration)
    {
        private readonly string _emailOrigen = configuration["EmailSettings:EmailOrigen"]!;
        private readonly string _contrasena = configuration["EmailSettings:Contrasena"]!;


        public void EnviarCorreo(string emailDestino, string asunto, string mensaje)
        {
            try
            {
                MailMessage mailMessage = new (_emailOrigen, emailDestino, asunto, mensaje)
                {
                    IsBodyHtml = true
                };

                SmtpClient smtpClient = new("smtp.gmail.com")
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential(_emailOrigen, _contrasena)
                };

                smtpClient.Send(mailMessage);
                smtpClient.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error al enviar el correo electronico: {ex.Message}");
            }
        }
    }
}
