
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class CitaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Cita> ObtenerTodos() => _contexto.Citas.AsNoTracking();

        public Cita? ObtenerPorId(Guid citaId) => _contexto.Citas.AsNoTracking().FirstOrDefault(x => x.CitaId == citaId);

        public void Insertar(Cita cita)
        {
            _contexto.Citas.Add(cita);
            _contexto.SaveChanges();
        }

        public void Actualizar(Cita cita)
        {
            _ = _contexto.Citas.AsNoTracking().FirstOrDefault(u => u.CitaId == cita.CitaId) ?? throw new Exception("La desparasitación no existe.");

            _contexto.Citas.Update(cita);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid citaId)
        {
            Cita cita = _contexto.Citas.AsNoTracking().FirstOrDefault(u => u.CitaId == citaId) ?? throw new Exception("La desparasitación no existe.");

            if (cita != null)
                _contexto.Citas.Remove(cita);
        }
    }
}
