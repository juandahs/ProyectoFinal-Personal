
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class DesparasitacionServicio (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Desparasitacion> ObtenerTodos() => _contexto.Desparasitaciones.AsNoTracking();

        public Desparasitacion? ObtenerPorId(Guid desparasitacionId) => _contexto.Desparasitaciones.AsNoTracking().FirstOrDefault(x => x.DesparasitacionId == desparasitacionId);

        public void Insertar(Desparasitacion desparasitacion)
        {
            _contexto.Desparasitaciones.Add(desparasitacion);
            _contexto.SaveChanges();
        }

        public void Actualizar(Desparasitacion desparasitacion)
        {
            _ = _contexto.Desparasitaciones.AsNoTracking().FirstOrDefault(u => u.DesparasitacionId == desparasitacion.DesparasitacionId) ?? throw new Exception("La desparasitación no existe.");

            _contexto.Desparasitaciones.Update(desparasitacion);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid desparacitacionId)
        {
            Desparasitacion desparacitacion = _contexto.Desparasitaciones.AsNoTracking().FirstOrDefault(u => u.DesparasitacionId == desparacitacionId) ?? throw new Exception("La desparasitación no existe.");

            if (desparacitacion != null)
                _contexto.Desparasitaciones.Remove(desparacitacion);
        }
    }
}
