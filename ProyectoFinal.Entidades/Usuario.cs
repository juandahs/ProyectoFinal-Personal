namespace ProyectoFinal.Entidades
{
    public class Usuario
    {
        public Guid UsuarioID { get; set; }
        public Guid TipoIdentificacionID { get; set; }
        public Guid RolID { get; set; }
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
        public Guid UsuarioCreacionID { get; set; }
        public Guid UsuarioModificacionID { get; set; }

        public virtual Rol? Rol { get; set; } 
        public virtual TipoIdentificacion? TipoIdentificacion { get; set; }  
        
    }
}
