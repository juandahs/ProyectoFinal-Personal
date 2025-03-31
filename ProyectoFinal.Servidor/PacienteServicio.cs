using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class PacienteServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Paciente> ObtenerTodos() => _contexto.Pacientes.Include(x => x.Propietario).AsNoTracking();

        public Paciente? ObtenerPorId(Guid id) => _contexto.Pacientes.Include(x => x.Propietario).AsNoTracking().FirstOrDefault(p => p.PacienteId == id);

        public void Agregar(Paciente paciente)
        {
            _contexto.Pacientes.Add(paciente);
            _contexto.SaveChanges();
        }

        public void Actualizar(Paciente paciente)
        {
            _ = _contexto.Pacientes.AsNoTracking().FirstOrDefault(u => u.PacienteId == paciente.PacienteId) ?? throw new Exception("El paciente no existe.");

            _contexto.Pacientes.Update(paciente);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var paciente = _contexto.Pacientes.AsNoTracking().FirstOrDefault(u => u.PacienteId == id);

            _contexto.Pacientes.Remove(_contexto.Pacientes.AsNoTracking().FirstOrDefault(u => u.PacienteId == id)!);
            _contexto.SaveChanges();
        }
        public bool Existe(Guid pacienteId) => _contexto.Pacientes.AsNoTracking().Any(x => x.PacienteId == pacienteId);

        public bool PuedeEliminar(Guid id)
        {
            var paciente = _contexto.Pacientes
                .Include(x => x.Vacunas)
                .AsNoTracking()
                .FirstOrDefault(u => u.PacienteId == id);

            return paciente != null && !paciente.Vacunas.Any();
        }
    }

}
