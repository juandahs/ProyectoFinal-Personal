
namespace ProyectoFinal.Entidades
{
    public class Cita
    {
        public Guid CitaId { get; set; }
        public Guid PropietarioId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Motivo { get; set; }
        public CitaEstado Estado{ get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        //Relaciones
        public virtual Usuario? Usuario { get; set; }
        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
        public virtual Paciente? Paciente { get; set; }


    }
}
