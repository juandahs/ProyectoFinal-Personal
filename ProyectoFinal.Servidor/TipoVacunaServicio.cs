using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using ProyectoFinal.Repositorio;

namespace ProyectoFinal.Servidor
{
    internal class TipoVacunaServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoVacuna> ObtenerTodos() => _contexto.TipoVacunas.AsNoTracking();
    }
}
