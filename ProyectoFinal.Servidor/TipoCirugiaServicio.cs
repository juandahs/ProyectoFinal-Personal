using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;


namespace ProyectoFinal.Servidor
{
    public class TipoCirugiaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoCirugia> ObtenerTodos() => _contexto.TipoCirugias.Include(x => x.UsuarioCreacion).Include(x => x.UsuarioModificacion).AsNoTracking();

        public TipoCirugia? ObtenerPorId(Guid tipoCirugiaId) => _contexto.TipoCirugias.Include(x => x.UsuarioCreacion).Include(x => x.UsuarioModificacion).AsNoTracking().FirstOrDefault(p => p.TipoCirugiaId == tipoCirugiaId);

        public void Agregar(TipoCirugia tipoCirugia)
        {
            try
            {
                _contexto.TipoCirugias.Add(tipoCirugia);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
            }
        }

        public void Actualizar(TipoCirugia tipoCirugia)
        {
            _ = _contexto.TipoCirugias.AsNoTracking().FirstOrDefault(u => u.TipoCirugiaId == tipoCirugia.TipoCirugiaId) ?? throw new Exception("El tipo de cirugía no existe.");

            _contexto.TipoCirugias.Update(tipoCirugia);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var tipoCirugia = _contexto.TipoCirugias.AsNoTracking().FirstOrDefault(u => u.TipoCirugiaId == id);
            if (tipoCirugia != null)
            {
                _contexto.TipoCirugias.Remove(tipoCirugia);
                _contexto.SaveChanges();
            }
        }
    }
}
