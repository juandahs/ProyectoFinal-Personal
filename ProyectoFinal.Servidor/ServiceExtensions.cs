using ProyectoFinal.Repositorio;
using Microsoft.AspNetCore.Builder; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 

namespace ProyectoFinal.Servidor
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrar el DbContext
            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registrar el servicio que usa el repositorio
            services.AddScoped<CitaServicio>();
            services.AddScoped<ConsultaServicio>();
            services.AddScoped<DesparasitacionServicio>();
            services.AddScoped<FormulaMedicaServicio>();
            services.AddScoped<MedicamentoServicio>();
            services.AddScoped<PacienteServicio>();
            services.AddScoped<PropietarioServicio>();
            services.AddScoped<UsuarioServicios>();
            services.AddScoped<TipoIdentificacionServicio>();
            services.AddScoped<RolServicio>();
            services.AddScoped<TipoExamenServicio>();
            services.AddScoped<ExamenServicio>();
            services.AddScoped<VacunaServicio>();
            services.AddScoped<CirugiaServicio>();
            services.AddScoped<TipoCirugiaServicio>();
            services.AddScoped<ImagenDiagnosticaServicio>();
            services.AddScoped<TipoImagenDiagnosticaServicio>();
            services.AddScoped<CorreoServicio>();


        }

        public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<Contexto>();
            await context.Database.MigrateAsync();

            if (!await context.TipoIdentificaciones.AnyAsync())
            {
                var sqlDatosPath = Path.Combine(AppContext.BaseDirectory, "AppData", "Datos.sql");
                var sqlDatos = await File.ReadAllTextAsync(sqlDatosPath);

                await context.Database.ExecuteSqlRawAsync(sqlDatos);
            }

            if (!await context.ProcedimientoAlmacenadoExisteAsync(Scripts.uspUsuarioValidoNombre))
                await context.Database.ExecuteSqlRawAsync(Scripts.uspUsuarioValido);

            if (!await context.ProcedimientoAlmacenadoExisteAsync(Scripts.uspUsuarioInsertarNombre))
                await context.Database.ExecuteSqlRawAsync(Scripts.uspUsuarioInsertar);

            if (!await context.ProcedimientoAlmacenadoExisteAsync(Scripts.uspUsuarioActualizarNombre))
                await context.Database.ExecuteSqlRawAsync(Scripts.uspUsuarioActualizar);

            if (!await context.ProcedimientoAlmacenadoExisteAsync(Scripts.uspUsuarioClaveActualizarNombre))
                await context.Database.ExecuteSqlRawAsync(Scripts.uspUsuarioClaveActualizar);
        }
    }
}
