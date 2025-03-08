namespace ProyectoFinal.Entidades
{
    public class TipoIdentificacion
    {
        public Guid TipoIdentificacionId { get; set; }
        public int Posicion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = [];

        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
    }
}
