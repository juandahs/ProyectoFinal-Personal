
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class CirugiaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<Cirugia> ObtenerTodos() => _contexto.Cirugias.Include(x => x.Paciente).Include(x=> x.TipoCirugia).AsNoTracking();

        public Cirugia? ObtenerPorId(Guid cirugiaId) => _contexto.Cirugias.Include(x=> x.Paciente).Include(x=> x.TipoCirugia).AsNoTracking().FirstOrDefault(p => p.CirugiaId == cirugiaId);

        public void Agregar(Cirugia cirugia)
        {
           _contexto.Cirugias.Add(cirugia);
           _contexto.SaveChanges();         
        }

        public void Actualizar(Cirugia cirugia)
        {
            _contexto.Cirugias.Update(cirugia);
            _contexto.SaveChanges();
        }


        public void Eliminar(Guid id)
        {
            var cirugia = _contexto.Cirugias.AsNoTracking().FirstOrDefault(u => u.CirugiaId == id);
            if (cirugia != null)
            {
                _contexto.Cirugias.Remove(cirugia);
                _contexto.SaveChanges();
            }
        }

        public bool Existe(Guid cirugiaId) => _contexto.Cirugias.AsNoTracking().Any(x => x.CirugiaId == cirugiaId);
        
    }
}
