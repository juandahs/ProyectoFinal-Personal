using Microsoft.EntityFrameworkCore;
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
            catch (Exception e)
            {
                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
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
            var propietario = _contexto.Propietarios.Include(x => x.Pacientes).AsNoTracking().FirstOrDefault(u => u.PropietarioId == id)
                              ?? throw new ArgumentNullException("No se encontro información del propietario.");

            if (propietario.Pacientes.Count != 0)
                throw new Exception("No se puede eliminar el propietario ya que tiene pacientes asociados.");
                        
            _contexto.Propietarios.Remove(propietario);
            _contexto.SaveChanges();
        }


        public bool Existe(string identifcacion) => _contexto.Propietarios.AsNoTracking().Any(x => x.NumeroIdentificacion== identifcacion);
    }
}
