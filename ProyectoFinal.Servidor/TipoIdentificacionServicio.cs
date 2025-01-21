using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class TipoIdentificacionServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoIdentificacion> ObtenerTodos()  => _contexto.TiposIdentificacion.AsNoTracking();
    }
}
