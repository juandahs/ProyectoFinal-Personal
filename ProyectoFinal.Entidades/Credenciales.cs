
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Entidades
{
    public class Credenciales
    {

        [Required(ErrorMessage ="El nombre de usuario es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria.")]
        public string Clave { get; set; } = string.Empty;
    }
}
