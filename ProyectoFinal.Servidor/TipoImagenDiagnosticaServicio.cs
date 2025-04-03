using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class TipoImagenDiagnosticaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoImagenDiagnostica> ObtenerTodos() => _contexto.TipoImagenesDiagnosticas.AsNoTracking();
    }
}