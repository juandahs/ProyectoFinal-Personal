
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
            try
            {
                _contexto.Cirugias.Add(cirugia);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
            }
        }

        public void Actualizar(Cirugia cirugia)
        {
            _ = _contexto.Cirugias.AsNoTracking().FirstOrDefault(u => u.CirugiaId == cirugia.CirugiaId) ?? throw new Exception("La cirugía no existe.");

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

        public bool Existe(DateTime FechaCreacion, Guid PacienteId, Guid TipoCirugiaId) => _contexto.Cirugias.AsNoTracking().Any(x => x.FechaCreacion == FechaCreacion && x.PacienteId == PacienteId && x.TipoCirugiaId ==TipoCirugiaId);

        public int TotalCirugias() => _contexto.Cirugias.Count();
    }
}
