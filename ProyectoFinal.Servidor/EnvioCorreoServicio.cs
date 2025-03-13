using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProyectoFinal.Servidor
{
    public class EnvioCorreoServicio(IConfiguration configuration)
    {
      public string  _emailOrigen = configuration["EmailSettings:EmailOrigen"];
      public string  _contrasena = configuration["EmailSettings:Contrasena"];
    }
}
