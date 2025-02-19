

namespace ProyectoFinal.Entidades
{
    public class Medicamento
    {
        public Guid MedicamentoId { get; set; }

        //TODO:  Falta crear la realcion con la entidad formulaMedica
        public Guid FormulaMedicaId { get; set; }

        public string NombreMedicamento { get; set; } = string.Empty;

        public string Dosis { get; set; } = string.Empty;
        public string Frecuencia { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        // Relaciones
        public virtual Usuario UsuarioCreacion { get; set; }
        public virtual Usuario UsuarioModificacion { get; set; }
        
        //public virtual FormulaMedica FormulaMedica { get; set; }


    }
}
