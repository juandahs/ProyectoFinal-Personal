using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CorreoElectronico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string EmailOrigen = "notificacionesvetsite@gmail.com";
            string EmailDestino = "notificacionesvetsite@gmail.com";
            string contrasena = "rsym dlmk fafz gthz";

            MailMessage mailMessage = new MailMessage(EmailOrigen, EmailDestino, "Asunto", "<b>Texto</b>");

            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, contrasena);


            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
        }
    }
}
