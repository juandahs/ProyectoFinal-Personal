namespace ProyectoFinal.Entidades
{
    public class Rol
    {
        public Guid RolId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; } = [];
    }
}
