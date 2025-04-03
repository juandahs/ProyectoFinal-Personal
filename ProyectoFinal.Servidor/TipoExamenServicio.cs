using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class TipoExamenServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoExamen> ObtenerTodos() => _contexto.TipoExamenes.Include(x => x.UsuarioCreacion).Include(x => x.UsuarioModificacion).AsNoTracking();

        public TipoExamen? ObtenerPorId(Guid tipoExamenId) => _contexto.TipoExamenes.AsNoTracking().FirstOrDefault(p => p.TipoExamenId == tipoExamenId);

        public void Agregar(TipoExamen tipoExamen)
        {
            try
            {
                _contexto.TipoExamenes.Add(tipoExamen);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Actualizar(TipoExamen tipoExamen)
        {            
            _contexto.TipoExamenes.Update(tipoExamen);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            _contexto.TipoExamenes.Remove(_contexto.TipoExamenes.AsNoTracking().FirstOrDefault(u => u.TipoExamenId == id)!);
            _contexto.SaveChanges();
        }

        public bool Existe(Guid tipoExamenId) => _contexto.TipoExamenes.AsNoTracking().Any(x => x.TipoExamenId == tipoExamenId);
    }
}
