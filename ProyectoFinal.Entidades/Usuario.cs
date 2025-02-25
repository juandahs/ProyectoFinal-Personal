namespace ProyectoFinal.Entidades
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public Guid TipoIdentificacionId { get; set; }
        public Guid RolId { get; set; }
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public string Nombre { get; set;} = string.Empty;
        public string Apellido { get; set;} = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public string? TarjetaProfesional { get; set; }
        public string Clave { get; set;} = string.Empty;
        public string Salt{ get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        public virtual Rol? Rol { get; set; } 
        public virtual TipoIdentificacion? TipoIdentificacion { get; set; }
        public virtual ICollection<Examen> Examenes { get; set; } = []; 
    }
}
