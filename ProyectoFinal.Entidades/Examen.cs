using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Examen
    {
        public Guid ExamenId { get; set; }

        public Guid PacienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoExamenId { get; set; }

        public DateTime Fecha { get; set; } 
        public string Descripcion { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        //Relaciones
        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
        public virtual Paciente? Paciente { get; set; }

        public virtual TipoExamen? TipoExamen { get; set; }


    }
}
