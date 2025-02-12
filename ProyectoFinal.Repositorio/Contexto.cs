﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;

namespace ProyectoFinal.Repositorio
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Definicion de nombres de las tablas
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<TipoIdentificacion>().ToTable("TipoIdentificacion");

            // ******************************************************************
            // Se define Tabla de Usuarios
            // ******************************************************************

            modelBuilder.Entity<Usuario>(t =>
            {
                t.Property(b => b.NumeroIdentificacion).HasColumnType("varchar").HasMaxLength(16).IsRequired();
                t.Property(b => b.Nombre).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.Apellido).HasColumnType("varchar").HasMaxLength(128);
                t.Property(b => b.Telefono).HasColumnType("varchar").HasMaxLength(16);
                t.Property(b => b.CorreoElectronico).HasColumnType("varchar").HasMaxLength(128);
                t.Property(b => b.TarjetaProfesional).HasColumnType("varchar").HasMaxLength(64);
                t.Property(b => b.Clave).HasColumnType("varchar").HasMaxLength(32).IsRequired();
                t.Property(b => b.Salt).HasColumnType("varchar").HasMaxLength(32).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                t.HasOne(b => b.Rol)
                .WithMany(b => b.Usuarios)
                .HasForeignKey(b => b.RolId).IsRequired();


                t.HasOne(b => b.TipoIdentificacion)
                .WithMany(b => b.Usuarios)
                .HasForeignKey(u => u.TipoIdentificacionId)
                .IsRequired();
            });

            // ******************************************************************
            // Se define Tabla de Roles
            // ******************************************************************

            modelBuilder.Entity<Rol>(t =>
            {
                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(16).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);


            });
            // ******************************************************************
            // Se define Tabla de TiposIdentificacion
            // ******************************************************************

            modelBuilder.Entity<TipoIdentificacion>(t =>
            {
                t.Property(b => b.TipoIdentificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(32).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId );

            });

            base.OnModelCreating(modelBuilder);
        }

        // Método para llamar al procedimiento almacenado
        public async Task<bool> ValidarClaveAsync(Guid usuarioId, string clave)
        {
            var resultado = new SqlParameter("@Resultado", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            // Parámetros de entrada
            var usuarioIdParam = new SqlParameter("@UsuarioID", usuarioId);
            var claveParam = new SqlParameter("@Clave", clave);

            // Ejecutar el procedimiento almacenado
            await Database.ExecuteSqlRawAsync(
                "EXEC @Resultado = uspUsuarioValido @UsuarioID, @Clave",
                resultado, usuarioIdParam, claveParam);

            // Obtener el valor del parámetro de salida
            int resultadoClave = (int)resultado.Value;

            // Convertir el resultado a booleano
            return resultadoClave == 1;
        }

        // Método para verificar si un procedimiento almacenado existe
        public async Task<bool> ProcedimientoAlmacenadoExisteAsync(string nombreProcedimiento)
        {
            // Define el parámetro para la consulta
            var nombreProcedimientoParameter = new SqlParameter("@NombreProcedimiento", nombreProcedimiento);

            // Ejecuta la consulta y obtiene el resultado
            var resultado = await this.Database
                .SqlQueryRaw<int>(@"
                    SELECT COUNT(*) 
                    FROM INFORMATION_SCHEMA.ROUTINES 
                    WHERE ROUTINE_TYPE = 'PROCEDURE' 
                    AND ROUTINE_NAME = @NombreProcedimiento", nombreProcedimientoParameter)
                .ToListAsync();

            // Retorna verdadero si el conteo es mayor que 0
            return resultado.FirstOrDefault() > 0;
        }

        public async Task UsuarioActualizar(Usuario usuario, Guid usuarioActualizacionId) 
        {
         
                var usuarioIdParameter = new SqlParameter(@"usuarioId", usuario.UsuarioId);
                var tipoIdentificacionIdParameter = new SqlParameter("@tipoIdentificacionId", usuario.TipoIdentificacionId);
                var rolIdParameter = new SqlParameter("@rolID", usuario.RolId);
                var numeroIdentificacionParameter = new SqlParameter("@numeroIdentificacion", usuario.NumeroIdentificacion);
                var nombreParameter = new SqlParameter("@nombre", usuario.Nombre);
                var apellidoParameter = new SqlParameter("@apellido", usuario.Apellido);
                var telefonoParameter = new SqlParameter("@telefono", usuario.Telefono);
                var correoElectronicoParameter = new SqlParameter("@correoElectronico", usuario.CorreoElectronico);
                var tarjetaProfesionalParameter = new SqlParameter("@tarjetaProfesional", usuario.TarjetaProfesional ?? (object)DBNull.Value);
                var fechaModificacionParameter = new SqlParameter("@fechaModificacion", DateTime.Now);
                var usuarioModificacionIdParameter = new SqlParameter("@usuarioModificacionId", usuarioActualizacionId);

                await Database.ExecuteSqlRawAsync("EXEC uspUsuarioActualizar @usuarioId, @tipoIdentificacionId, @rolId, @numeroIdentificacion, @nombre, @apellido, @telefono, @correoElectronico, @tarjetaProfesional, @fechaModificacion, @usuarioModificacionId"
                    , usuarioIdParameter
                    , tipoIdentificacionIdParameter
                    , rolIdParameter
                    , numeroIdentificacionParameter
                    , nombreParameter
                    , apellidoParameter
                    , telefonoParameter
                    , correoElectronicoParameter
                    , tarjetaProfesionalParameter
                    , fechaModificacionParameter
                    , usuarioModificacionIdParameter);
           
        }

        public async Task UsuarioInsertar(Usuario usuario, Guid usuarioCreacionId) 
        {
            var tipoIdentificacionIdParameter = new SqlParameter("@tipoIdentificacionId", usuario.TipoIdentificacionId);
            var rolIdParameter = new SqlParameter("@rolID", usuario.RolId);
            var numeroIdentificacionParameter = new SqlParameter("@numeroIdentificacion", usuario.NumeroIdentificacion);
            var nombreParameter = new SqlParameter("@nombre", usuario.Nombre);
            var apellidoParameter = new SqlParameter("@apellido", usuario.Apellido);
            var telefonoParameter = new SqlParameter("@telefono", usuario.Telefono);
            var correoElectronicoParameter = new SqlParameter("@correoElectronico", usuario.CorreoElectronico);
            var tarjetaProfesionalParameter = new SqlParameter("@tarjetaProfesional",usuario.TarjetaProfesional ?? (object)DBNull.Value);
            var claveParameter = new SqlParameter("@clave", usuario.Clave);
            var fechaCreacionParameter = new SqlParameter("@fechaCreacion", DateTime.Now);  
            var usuarioCreacionIdParameter = new SqlParameter("@usuarioCreacionID", usuarioCreacionId);
            
            

            await Database.ExecuteSqlRawAsync(
                "EXEC uspUsuarioInsertar @tipoIdentificacionId, @RolID, @NumeroIdentificacion, @Nombre, @Apellido, @Telefono, @CorreoElectronico, @TarjetaProfesional, @Clave, @FechaCreacion, @UsuarioCreacionID",
                tipoIdentificacionIdParameter,
                rolIdParameter,
                numeroIdentificacionParameter,
                nombreParameter,
                apellidoParameter,
                telefonoParameter,
                correoElectronicoParameter,
                tarjetaProfesionalParameter,
                claveParameter,
                fechaCreacionParameter,                
                usuarioCreacionIdParameter
                
             );
        }


    }
}
