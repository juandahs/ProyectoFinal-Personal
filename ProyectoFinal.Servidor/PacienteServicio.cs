using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class PacienteServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Paciente> ObtenerTodos() => _contexto.Pacientes.Include(x => x.Propietario).AsNoTracking().OrderBy(x => x.Nombre).ThenBy(x => x.PropietarioId).ThenBy(x => x.Edad);

        public Paciente? ObtenerPorId(Guid id) => _contexto.Pacientes.Include(x => x.Propietario).AsNoTracking().FirstOrDefault(p => p.PacienteId == id);

        public void Agregar(Paciente paciente)
        {
            _contexto.Pacientes.Add(paciente);
            _contexto.SaveChanges();
        }

        public void Actualizar(Paciente paciente)
        {
            _contexto.Pacientes.Update(paciente);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            _contexto.Pacientes.Remove(_contexto.Pacientes.AsNoTracking().FirstOrDefault(u => u.PacienteId == id)!);
            _contexto.SaveChanges();
        }

        public bool Existe(Guid pacienteId) => _contexto.Pacientes.AsNoTracking().Any(x => x.PacienteId == pacienteId);

    }

}
