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
    public class TipoExamenServicio(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;
        public IEnumerable<TipoExamen> ObtenerTodos() => _contexto.TipoExamenes.AsNoTracking();
    }
}
