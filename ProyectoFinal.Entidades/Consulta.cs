namespace ProyectoFinal.Entidades
{
    public class Consulta
    {
        public Guid ConsultaId { get; set; } = Guid.NewGuid();
        public Guid PacienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid CitaId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Motivo { get; set; }
        public string Sintomas { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Cita Cita { get; set; }
        public virtual Usuario UsuarioCreacion { get; set; }
        public virtual Usuario UsuarioModificacion { get; set; }
    }
}
