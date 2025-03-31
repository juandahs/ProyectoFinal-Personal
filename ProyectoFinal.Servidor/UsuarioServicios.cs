using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;


namespace ProyectoFinal.Servidor
{
    public class UsuarioServicios (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public Usuario? ObtenerPorCorreoElectronico(string correoElectronico) => _contexto.Usuarios.AsNoTracking().FirstOrDefault(x => x.CorreoElectronico == correoElectronico);

        public List<Usuario> ObtenerTodos() => [.. _contexto.Usuarios.AsNoTracking()];
        
        public bool EsValido(Guid usuarioId, string clave) => _contexto.ValidarClaveAsync(usuarioId, clave).Result;

        public void Agregar(Usuario usuario, Guid usuarioCreacionId) => _contexto.UsuarioInsertar(usuario, usuarioCreacionId).GetAwaiter().GetResult();

        public Usuario? ObtenerPorId(Guid id) => _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);

        public void Actualizar(Usuario usuario, Guid usuarioModificacionId) =>
            _contexto.UsuarioActualizar(usuario, usuarioModificacionId).GetAwaiter().GetResult() ;

        public void Eliminar(Guid usuarioId)
        {            
            var usuario = _contexto.Usuarios.AsNoTracking().FirstOrDefault(u => u.UsuarioId == usuarioId);

            if (usuario != null)
            {
                _contexto.Usuarios.Remove(usuario);
                _contexto.SaveChanges();
            }
        }

        public bool Existe(string correoElectronico, string numeroIdentificacion)  => _contexto.Usuarios.AsNoTracking().Any(x => x.CorreoElectronico == correoElectronico || x.NumeroIdentificacion == numeroIdentificacion);

        public bool Existe(Guid usuarioId) => _contexto.Usuarios.AsNoTracking().Any(x => x.UsuarioId == usuarioId);

        public int TotalUsuarios() => _contexto.Usuarios.Count();

        public void ActualizarClave(Guid usuarioId, string nuevaClave) => _contexto.UsuarioActualizarClave(usuarioId, nuevaClave).GetAwaiter().GetResult();

       

    }
}
