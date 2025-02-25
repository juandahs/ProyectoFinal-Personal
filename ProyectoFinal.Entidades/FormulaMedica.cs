namespace ProyectoFinal.Entidades
{
    public class FormulaMedica
    {
        public Guid FormulaMedicaId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Usuario UsuarioCreacion { get; set; }
        public virtual Usuario UsuarioModidificacion{ get; set; }
    }
}
