namespace ProyectoFinal.Entidades
{
    public class Propietario
    {
        public Guid PropietarioId { get; set; } 

        public Guid TipoIdentificacionId { get; set; }

        public string NumeroIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Direccion { get; set; }

        // Fechas de creación y modificación
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }
        public virtual Usuario UsuarioCreacion { get; set; } 
        public virtual Usuario UsuarioModificacion { get; set; } 
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
    }

}
