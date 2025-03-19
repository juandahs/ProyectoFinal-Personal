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

        public string _asunto = "Cita programada";
        public string _plantilla = """ 

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
