using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class ExamenServicio (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Examen> ObtenerTodos() => _contexto.Examenes.AsNoTracking();

        public Examen? ObtenerPorId(Guid ExamenId) => _contexto.Examenes.AsNoTracking().FirstOrDefault(x => x.ExamenId == ExamenId);

        public void Agregar(Examen examen)
        {
            _contexto.Examenes.Add(examen);
            _contexto.SaveChanges();
        }

        public void Actualizar(Examen examen)
        {
            _ = _contexto.Examenes.AsNoTracking().FirstOrDefault(u => u.ExamenId == examen.ExamenId) ?? throw new Exception("El Examen no existe.");

            _contexto.Examenes.Update(examen);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid examenId)
        {
            Examen examen = _contexto.Examenes.AsNoTracking().FirstOrDefault(u => u.ExamenId == examenId) ?? throw new Exception("El Examen no existe.");

            if (examen != null)
                _contexto.Examenes.Remove(examen);
        }
    }
}
