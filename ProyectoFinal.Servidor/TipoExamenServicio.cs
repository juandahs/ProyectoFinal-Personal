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
       

        public void Eliminar(Guid id)
        {
            var tipoExamen = _contexto.TipoExamenes.AsNoTracking().FirstOrDefault(u => u.TipoExamenId == id);
            if (tipoExamen != null)
            {
                _contexto.TipoExamenes.Remove(tipoExamen);
                _contexto.SaveChanges();
            }
        }

        public void Actualizar(TipoExamen tipoExamen)
        {
            _ = _contexto.TipoExamenes.AsNoTracking().FirstOrDefault(u => u.TipoExamenId== tipoExamen.TipoExamenId) ?? throw new Exception("El tipo de examen no existe.");

            _contexto.TipoExamenes.Update(tipoExamen);
            _contexto.SaveChanges();
        }
    }
}
