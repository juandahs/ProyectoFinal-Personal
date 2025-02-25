using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class TipoVacuna
    {
        
        public Guid TipoVacunaId { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
        public Guid UsuarioModificacionId { get; set; }


        //Relaciones
        public virtual Usuario? UsuarioCreacion { get; set; }
        public virtual Usuario? UsuarioModificacion { get; set; }
        public virtual Vacuna? Vacuna { get; set; } //Relacin de uno a uno

    }
}
