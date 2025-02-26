
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

        public void Insertar(Medicamento medicamento)
        {
            _contexto.Medicamentos.Add(medicamento);
            _contexto.SaveChanges();
        }

        public void Actualizar(Medicamento medicamento)
        {
            _ = _contexto.Medicamentos.AsNoTracking().FirstOrDefault(u => u.MedicamentoId == medicamento.MedicamentoId) ?? throw new Exception("El medicamento no existe.");

            _contexto.Medicamentos.Update(medicamento);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid medicamentoId)
        {
            Medicamento medicamento = _contexto.Medicamentos.AsNoTracking().FirstOrDefault(u => u.MedicamentoId == medicamentoId) ?? throw new Exception("El medicamento no existe.");

            if (medicamento != null)
                _contexto.Medicamentos.Remove(medicamento);
        }


    }
}
