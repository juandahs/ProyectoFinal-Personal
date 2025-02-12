using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;


namespace ProyectoFinal.Servidor
{
    public class UsuarioServicios (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public Usuario? ObtenerPorNombre(string nombreUsuario) => _contexto.Usuarios.AsNoTracking().FirstOrDefault(x => x.Nombre == nombreUsuario);

        public Usuario? ObtenerPorCorreoElectronico(string correoElectronico) => _contexto.Usuarios.AsNoTracking().FirstOrDefault(x => x.CorreoElectronico == correoElectronico);

        public List<Usuario> ObtenerTodos() => [.. _contexto.Usuarios.AsNoTracking()];

        
        public bool EsValido(Guid usuarioId, string clave) => _contexto.ValidarClaveAsync(usuarioId, clave).Result;

        public void Agregar(Usuario usuario, Guid usuarioCreacionId) => _contexto.UsuarioInsertar(usuario, usuarioCreacionId).GetAwaiter().GetResult();


        public Usuario? ObtenerPorId(Guid id) => _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);

        public void Actualizar(Usuario usuario, Guid usuarioModificacionId)
        {
            var usuarioDb = _contexto.Usuarios.AsNoTracking().FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId) ?? throw new Exception("El usuario no existe.");

            _contexto.UsuarioActualizar(usuario, usuarioModificacionId).GetAwaiter().GetResult() ;
        }

        public void Eliminar(Guid usuarioId)
        {
            var usuario = _contexto.Usuarios.AsNoTracking().FirstOrDefault(u => u.UsuarioId == usuarioId) ?? throw new Exception("El usuario no existe.");

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
        }

       
    }
}
