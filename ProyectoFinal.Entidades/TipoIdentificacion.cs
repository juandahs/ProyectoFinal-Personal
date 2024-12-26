﻿namespace ProyectoFinal.Entidades
{
    public class TipoIdentificacion
    {
        public Guid TipoIdentificacionID { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCreacionID { get; set; }
        public Guid UsuarioModificacionID { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = [];
    }
}
