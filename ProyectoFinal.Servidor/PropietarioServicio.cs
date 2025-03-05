﻿using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;


namespace ProyectoFinal.Servidor
{
    public class PropietarioServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Propietario> ObtenerTodos() => _contexto.Propietarios.AsNoTracking();

        public Propietario? ObtenerPorId(Guid id) => _contexto.Propietarios.AsNoTracking().FirstOrDefault(p => p.PropietarioId == id);

        public void Agregar(Propietario propietario)
        {
            try
            {
                _contexto.Propietarios.Add(propietario);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Actualizar(Propietario propietario)
        {
            _ = _contexto.Propietarios.AsNoTracking().FirstOrDefault(u => u.PropietarioId == propietario.PropietarioId) ?? throw new Exception("El propietario no existe.");

            _contexto.Propietarios.Update(propietario);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var propietario = _contexto.Propietarios.AsNoTracking().FirstOrDefault(u => u.PropietarioId == id);
            if (propietario != null)
            {
                _contexto.Propietarios.Remove(propietario);
                _contexto.SaveChanges();
            }
        }
    }
}
