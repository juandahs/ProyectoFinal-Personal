

namespace ProyectoFinal.Entidades
{
    public class ImagenDiagnostica
    {
        public Guid ImagenDiagnosticaId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoImagenDiagnosticaId { get; set; }
        public DateTime Fecha { get; set; }
        public string? SignosClinicos { get; set; }
        public string? DiagnosticoPresuntivo { get; set; }
        public byte[] Imagen { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        //Relaciones
        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
        public virtual Paciente? Paciente { get; set; }

        //public virtual TipoImagenDiagnostica? TipoImagenDiagnostica { get; set; }




    }
}
