using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    public class ImagenDiagnosticaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<ImagenDiagnostica> ObtenerTodos() => _contexto.ImagenesDiagnosticas.AsNoTracking();

        public ImagenDiagnostica? ObtenerPorId(Guid id) => _contexto.ImagenesDiagnosticas.AsNoTracking().FirstOrDefault(p => p.ImagenDiagnosticaId == id);

        public void Agregar(ImagenDiagnostica imagenDiagnostica)
        {
            _contexto.ImagenesDiagnosticas.Add(imagenDiagnostica);
            _contexto.SaveChanges();
        }

        public void Actualizar(ImagenDiagnostica imagenDiagnostica)
        {
            _ = _contexto.ImagenesDiagnosticas.AsNoTracking().FirstOrDefault(u => u.PacienteId == imagenDiagnostica.ImagenDiagnosticaId) ?? throw new Exception("La imagen diagnostica no existe.");

            _contexto.ImagenesDiagnosticas.Update(imagenDiagnostica);
            _contexto.SaveChanges();
        }

        public void Eliminar(Guid id)
        {
            var imagenDiagnostica = _contexto.ImagenesDiagnosticas.AsNoTracking().FirstOrDefault(u => u.PacienteId == id);
            if (imagenDiagnostica != null)
            {
                _contexto.ImagenesDiagnosticas.Remove(imagenDiagnostica);
                _contexto.SaveChanges();
            }
        }
    }
}