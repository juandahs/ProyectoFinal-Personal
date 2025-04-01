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
            _contexto.TipoCirugias.Update(tipoCirugia);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {   
            _contexto.TipoCirugias.Remove(_contexto.TipoCirugias.AsNoTracking().FirstOrDefault(u => u.TipoCirugiaId == id)!);
            _contexto.SaveChanges();
        }


        public bool Existe(Guid tipoCirugiaId) => _contexto.TipoCirugias.AsNoTracking().Any(x => x.TipoCirugiaId == tipoCirugiaId);

    }
}
