namespace ProyectoFinal.Entidades
{
    public class Cirugia
    {
        public Guid CirugiaId { get; set; }         
        public Guid TipoCirugiaId { get; set; } 
        public Guid PacienteId { get; set; }                
        public Guid UsuarioId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Preanestesico { get; set; } = string.Empty;
        public string? Observaciones {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        //Relaciones
        public virtual Usuario? Usuario { get; set; }
        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
        public virtual Paciente? Paciente { get; set; }
        public virtual TipoCirugia? TipoCirugia { get; set; }        


    }
}
