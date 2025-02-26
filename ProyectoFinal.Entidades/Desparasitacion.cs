

namespace ProyectoFinal.Entidades
{
    public class Desparasitacion
    {
        public Guid DesparasitacionId { get; set; }

        public Guid PacienteId { get; set; }
        public DesparasitacionTipo DesparasitacionTipo { get; set; }
        public DesparasitacionForma DesparasitacionForma { get; set; }

        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaProximaAplicacion { get; set; }

        public string?  Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        public virtual Paciente Paciente { get; set; }        
        public virtual Paciente UsuarioCreacion { get; set; }
        public virtual Usuario  UsuarioModificacion { get; set; }

    }
}
