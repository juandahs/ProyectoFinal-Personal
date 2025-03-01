using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Servidor
{
    public class TipoImagenDiagnosticaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoImagenDiagnostica> ObtenerTodos() => _contexto.TipoImagenesDiagnosticas.AsNoTracking();
    }
}