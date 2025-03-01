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
    public class VacunaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Vacuna> ObtenerTodos() => _contexto.Vacunas.AsNoTracking();

        public Vacuna? ObtenerPorId(Guid vacunaId) => _contexto.Vacunas.AsNoTracking().FirstOrDefault(p => p.VacunaId == vacunaId);

        public void Agregar(Vacuna vacuna)
        {
            _contexto.Vacunas.Add(vacuna);
            _contexto.SaveChanges();
        }

        public void Actualizar(Vacuna vacuna)
        {
            _ = _contexto.Vacunas.AsNoTracking().FirstOrDefault(u => u.VacunaId == vacuna.VacunaId) ?? throw new Exception("La Vacuna no existe.");

            _contexto.Vacunas.Update(vacuna);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid vacunaId)
        {
            Vacuna vacuna = _contexto.Vacunas.AsNoTracking().FirstOrDefault(u => u.VacunaId == vacunaId) ?? throw new Exception("La vacuna no existe.");

            if (vacuna != null)
                _contexto.Vacunas.Remove(vacuna);
        }
    }
}
