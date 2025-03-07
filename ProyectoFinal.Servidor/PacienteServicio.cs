﻿using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class PacienteServicio (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Paciente> ObtenerTodos() => _contexto.Pacientes.Include(x => x.Propietario).AsNoTracking();

        public Paciente? ObtenerPorId(Guid id) => _contexto.Pacientes.AsNoTracking().FirstOrDefault(p => p.PacienteId == id);

        public void Agregar(Paciente paciente)
        {

            try
            {
                _contexto.Pacientes.Add(paciente);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
            }
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
            if (paciente != null)
            {
                _contexto.Pacientes.Remove(paciente);
                _contexto.SaveChanges();
            }
        }
    }

}
