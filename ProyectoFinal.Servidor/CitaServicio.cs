using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ProyectoFinal.Servidor
{
    public class CitaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public IEnumerable<Cita> ObtenerTodos() => _contexto.Citas.Include(x => x.Paciente).Include(x => x.Usuario).AsNoTracking();

        public Cita? ObtenerPorId(Guid citaId) => _contexto.Citas.AsNoTracking().FirstOrDefault(x => x.CitaId == citaId);

        public void Insertar(Cita cita)
        {
            try
            {
                _contexto.Citas.Add(cita);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(message: $"message: {e.Message} inner: {e.InnerException}");
            }
        }

        public void Actualizar(Cita cita)
        {
            _ = _contexto.Citas.AsNoTracking().FirstOrDefault(u => u.CitaId == cita.CitaId) ?? throw new Exception("La cita no existe.");

            _contexto.Citas.Update(cita);
            _contexto.SaveChanges();
        }

        public void EditarEstado(Guid citaId, CitaEstado nuevoEstado, Guid usuarioModificacionId)
        {
            var cita = _contexto.Citas.FirstOrDefault(c => c.CitaId == citaId);

            if (cita == null)
            {
                throw new Exception("La cita no existe.");
            }

            cita.Estado = nuevoEstado;
            cita.UsuarioModificacionId = usuarioModificacionId;
            cita.FechaModificacion = DateTime.Now;

            _contexto.Entry(cita).Property(x => x.Estado).IsModified = true;
            _contexto.Entry(cita).Property(x => x.UsuarioModificacionId).IsModified = true;
            _contexto.Entry(cita).Property(x => x.FechaModificacion).IsModified = true;

            _contexto.SaveChanges();
        }

        public bool Existe(Guid citaId) => _contexto.Citas.AsNoTracking().Any(x => x.CitaId == citaId);



    }
}
