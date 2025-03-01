
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class CirugiaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<Cirugia> ObtenerTodos() => _contexto.Cirugias.AsNoTracking();

        public Cirugia? ObtenerPorId(Guid id) => _contexto.Cirugias.AsNoTracking().FirstOrDefault(p => p.CirugiaId == id);

        public void Agregar(Cirugia cirugia)
        {
            _contexto.Cirugias.Add(cirugia);
            _contexto.SaveChanges();
        }

        public void Actualizar(Cirugia cirugia)
        {
            _ = _contexto.Cirugias.AsNoTracking().FirstOrDefault(u => u.PacienteId == cirugia.CirugiaId) ?? throw new Exception("La cirugía no existe.");

            _contexto.Cirugias.Update(cirugia);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var cirugia = _contexto.Cirugias.AsNoTracking().FirstOrDefault(u => u.PacienteId == id);
            if (cirugia != null)
            {
                _contexto.Cirugias.Remove(cirugia);
                _contexto.SaveChanges();
            }
        }
    }
}
