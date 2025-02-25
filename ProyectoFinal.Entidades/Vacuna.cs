using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Vacuna
    {
        public Guid VacunaId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoVacunaId { get; set; }

        public string? Laboratorio { get; set; }
        public string? Lote { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaProximaAplicacion { get; set; }
        public string? Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        //Relaciones
        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual Paciente? Paciente { get; set; }
        public virtual TipoVacuna? TipoVacuna { get; set; }
    }
}
