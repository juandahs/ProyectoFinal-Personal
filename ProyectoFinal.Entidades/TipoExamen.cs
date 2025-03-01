
namespace ProyectoFinal.Entidades
{
    public class TipoExamen
    {
        
        public Guid TipoExamenId { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        public virtual Examen? Examenes { get; set; }

        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }

    }
}
