using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ProyectoFinal.Servidor
{
    public class UsuarioServicios (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public Usuario? ObtenerPorNombre(string nombreUsuario) => _contexto.Usuarios.AsNoTracking().FirstOrDefault(x => x.Nombre == nombreUsuario);

        public List<Usuario> ObtenerTodos() => _contexto.Usuarios.AsNoTracking().ToList();

        
        public bool EsValido(Guid usuarioId, string clave) => _contexto.ValidarClaveAsync(usuarioId, clave).Result;

        public void Agregar(Usuario usuario, Guid usuarioCreacionId) => _contexto.UsuarioInsertar(usuario, usuarioCreacionId).GetAwaiter().GetResult();


        public Usuario? ObtenerPorId(Guid id) => _contexto.Usuarios.FirstOrDefault(u => u.UsuarioID == id);

        public void Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid usuarioId)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.UsuarioID == usuarioId);
            if (usuario == null)
                throw new Exception("El usuario no existe.");

            // Aquí podrías registrar auditoría si lo necesitas, usando `usuarioAutenticadoId`.

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
        }

    }
}
