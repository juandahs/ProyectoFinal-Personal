using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class VacunaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Vacuna> ObtenerTodos() => _contexto.Vacunas.Include(x => x.Paciente).AsNoTracking();

        public Vacuna? ObtenerPorId(Guid vacunaId) => _contexto.Vacunas.AsNoTracking().FirstOrDefault(p => p.VacunaId == vacunaId);

        public void Agregar(Vacuna vacuna)
        {
            try
            {
                _contexto.Vacunas.Add(vacuna);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
            }
        }

        public void Actualizar(Vacuna vacuna)
        {
            _contexto.Vacunas.Update(vacuna);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            _contexto.Vacunas.Remove(_contexto.Vacunas.AsNoTracking().FirstOrDefault(u => u.VacunaId == id)!);
            _contexto.SaveChanges();
        }

        public bool Existe(Guid vacunaId) => _contexto.Vacunas.AsNoTracking().Any(x => x.VacunaId == vacunaId);

    }
}
