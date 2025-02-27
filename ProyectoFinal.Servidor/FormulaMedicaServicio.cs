using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;


namespace ProyectoFinal.Servidor
{
    public class FormulaMedicaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<FormulaMedica> ObtenerTodos() => _contexto.FormulasMedicas.AsNoTracking();

        public FormulaMedica? ObtenerPorId(Guid id) => _contexto.FormulasMedicas.AsNoTracking().FirstOrDefault(f => f.FormulaMedicaId == id);

        public void Agregar(FormulaMedica formulaMedica)
        {
            _contexto.FormulasMedicas.Add(formulaMedica);
            _contexto.SaveChanges();
        }

        public void Actualizar(FormulaMedica formulaMedica)
        {
            _ = _contexto.FormulasMedicas.AsNoTracking().FirstOrDefault(u => u.FormulaMedicaId == formulaMedica.FormulaMedicaId) ?? throw new Exception("La formula medica no existe.");

            _contexto.FormulasMedicas.Update(formulaMedica);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var formulaMedica = contexto.FormulasMedicas.AsNoTracking().FirstOrDefault(u => u.FormulaMedicaId == id);
            if (formulaMedica != null)
            {
                _contexto.FormulasMedicas.Remove(formulaMedica);
                _contexto.SaveChanges();
            }
        }

    
    }

}
