using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class ExamenServicio (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Examen> ObtenerTodos() => _contexto.Examenes.Include(x =>x.TipoExamen).Include(x => x.Usuario).AsNoTracking();

        public Examen? ObtenerPorId(Guid ExamenId) => _contexto.Examenes.Include(x => x.TipoExamen).AsNoTracking().FirstOrDefault(x => x.ExamenId == ExamenId);

        public void Agregar(Examen examen)
        {
            _contexto.Examenes.Add(examen);
            _contexto.SaveChanges();
        }

        public void Actualizar(Examen examen)
        {
            _ = _contexto.Examenes.AsNoTracking().FirstOrDefault(u => u.ExamenId == examen.ExamenId) ?? throw new Exception("El examen no existe.");

            _contexto.Examenes.Update(examen);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {           
            var examen = _contexto.Examenes.AsNoTracking().FirstOrDefault(u => u.ExamenId == id);

            if (examen != null)
            {
                _contexto.Examenes.Remove(examen);
                _contexto.SaveChanges();
            }
        }

        public bool Existe(Guid examenId) => _contexto.Examenes.AsNoTracking().Any(x => x.ExamenId == examenId);        

    }
}
