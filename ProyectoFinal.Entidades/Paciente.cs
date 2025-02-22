

namespace ProyectoFinal.Entidades
{
    public class Paciente
    {
        public Guid PacienteId { get; set; } = Guid.NewGuid();
        public Guid PropietarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public char Sexo { get; set; }
        public string Especie { get; set; } = string.Empty;
        public decimal Peso { get; set; }
        public string Raza { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Edad { get; set; }
        public bool Esterilizado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }

        // Relaciones
        public virtual Usuario UsuarioCreacion { get; set; }
        public virtual Usuario UsuarioModificacion { get; set; }

        public virtual ICollection<Cita> Citas { get; set; } = [];
        public virtual ICollection<Examen> Examenes { get; set; } = []; //un paciente puede tener varios examnes
        public virtual ICollection<Vacuna> Vacunas { get; set; } = []; //un paciente puede tener varios examnes
    }

}
