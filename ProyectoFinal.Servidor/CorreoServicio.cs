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

        public string plantilla = """ 

            <!DOCTYPE html>
      <html lang="en" xmlns="http://www.w3.org/1999/xhtml" >
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
              }

              .container {
                  width: 100%;
                  max-width: 600px;
                  margin: auto;
                  border: 1px solid #ddd;
                  border-radius: 8px;
                  overflow: hidden;
                  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
              }

              .header {
                  background-color: #007ea7;
                  padding: 20px;
              }

                  .header img {
                      max-width: 150px;
                  }

              .content {
                  padding: 20px;
                  text-align: left;
              }

                  .content h2 {
                      color: #007ea7;
                  }

              .footer {
                  background-color: #f8f8f8;
                  padding: 15px;
                  font-size: 14px;
                  color: #555;
              }

              .button {
                  display: inline-block;
                  padding: 10px 20px;
                  margin-top: 20px;
                  background-color: #007ea7;
                  color: #ffffff;
                  text-decoration: none;
                  border-radius: 5px;
                  font-weight: bold;
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
                  <p><strong>Propietario:</strong> {NombrePropietario}</p>
                  <p><strong>Mascota:</strong> {NombreMascota}</p>
                  <p><strong>Servicio:</strong> {Servicio}</p>
                  <p><strong>Fecha:</strong> {Fecha}</p>
                  <p><strong>Hora:</strong> {Hora}</p>
                  <a href="{URLConfirmacion}" class="button">Confirmar Cita</a>
              </div>
              <div class="footer">
                  <p>Gracias por confiar en nuestra clínica veterinaria.</p>
                  <p>Para mayor información contactanos @notofic.</p>
              </div>
          </div>
      </body>
      </html>

      """;

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
                throw new Exception($"Ocurrio el siguiente error al enviar el correo electronico: {ex.Message}");
            }
        }
    }
}
