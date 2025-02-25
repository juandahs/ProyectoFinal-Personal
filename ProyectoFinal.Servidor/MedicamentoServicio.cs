
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class MedicamentoServicio(Contexto contexto) 
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Medicamento> ObtenerTodos() => _contexto.Medicamentos.AsNoTracking();
        public Medicamento? ObtenerPorId(Guid medicamentoId) => _contexto.Medicamentos.AsNoTracking().FirstOrDefault(x => x.MedicamentoId == medicamentoId);


    }
}
