
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class ConsultaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<Consulta> ObtenerTodos() => _contexto.Consultas.AsNoTracking();

        public Consulta? ObtenerPorId(Guid id) => _contexto.Consultas.AsNoTracking().FirstOrDefault(p => p.ConsultaId == id);

        public void Agregar(Consulta consulta)
        {
            try
            {
                _contexto.Consultas.Add(consulta);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
            }
        }

        public void Actualizar(Consulta consulta)
        {
            _ = _contexto.Consultas.AsNoTracking().FirstOrDefault(u => u.PacienteId == consulta.ConsultaId) ?? throw new Exception("La consulta no existe.");

            _contexto.Consultas.Update(consulta);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var consulta = _contexto.Consultas.AsNoTracking().FirstOrDefault(u => u.PacienteId == id);
            if (consulta != null)
            {
                _contexto.Consultas.Remove(consulta);
                _contexto.SaveChanges();
            }
        }
    }
}
