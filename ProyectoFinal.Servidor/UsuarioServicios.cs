using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class UsuarioServicios (Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public Usuario? ObtenerPorNombre(string nombreUsuario) => _contexto.Usuarios.AsNoTracking().FirstOrDefault(x => x.Nombre == nombreUsuario);

        public List<Usuario> ObtenerTodos() => _contexto.Usuarios.AsNoTracking().ToList();

        public bool EsValido(Guid usuarioId, string clave) => _contexto.ValidarClaveAsync(usuarioId, clave).Result;

        public void Agregar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario? ObtenerPorId(Guid id) => _contexto.Usuarios.FirstOrDefault(u => u.UsuarioID == id);

        public void Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
