
namespace ProyectoFinal.Entidades
{
    public class FormulaMedicaMedicamento
    {
        public Guid FormulaMedicaId { get; set; }
        public Guid MedicamentoId { get; set; }

        public virtual FormulaMedica? FormulaMedica { get; set; }
        public virtual Medicamento? Medicamento { get; set; }
    }
}
