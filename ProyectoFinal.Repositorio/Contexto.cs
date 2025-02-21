using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;
using System.Net.Http.Headers;

namespace ProyectoFinal.Repositorio
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Cirugia> Cirugias { get; set; }
        public DbSet<TipoCirugia> TipoCirugias { get; set; }
        public DbSet<TipoExamen> TipoExamens { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<TipoVacuna> TipoVacunas { get; set; }



        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Definicion de nombres de las tablas
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<TipoIdentificacion>().ToTable("TipoIdentificacion");
            modelBuilder.Entity<Medicamento>().ToTable("Medicamento");
            modelBuilder.Entity<Cirugia>().ToTable("Cirugia");
            modelBuilder.Entity<TipoCirugia>().ToTable("TipoCirugia");
            modelBuilder.Entity<TipoExamen>().ToTable("TipoExamen");
            modelBuilder.Entity<Examen>().ToTable("Examen");
            modelBuilder.Entity<TipoVacuna>().ToTable("TipoVacuna");

            // ******************************************************************
            // Se define Tabla de Usuarios
            // ******************************************************************

            modelBuilder.Entity<Usuario>(t =>
            {
                t.Property(b => b.NumeroIdentificacion).HasColumnType("varchar").HasMaxLength(16).IsRequired();
                t.Property(b => b.Nombre).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.CorreoElectronico).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.Apellido).HasColumnType("varchar").HasMaxLength(128);
                t.Property(b => b.Telefono).HasColumnType("varchar").HasMaxLength(16);
                t.Property(b => b.TarjetaProfesional).HasColumnType("varchar").HasMaxLength(64);
                t.Property(b => b.Clave).HasColumnType("varchar").HasMaxLength(32).IsRequired();
                t.Property(b => b.Salt).HasColumnType("varchar").HasMaxLength(32).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);
                t.HasIndex(b => b.CorreoElectronico).IsUnique();

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
                t.Property(b => b.TipoIdentificacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(32).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

            });

            // ******************************************************************
            // Se define Tabla de Cita
            // ******************************************************************

            modelBuilder.Entity<Cita>(t =>
            {

                t.Property(b => b.CitaId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.PropietarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(b => b.FechaCreacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(b => b.FechaModificacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(b => b.UsuarioCreacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.UsuarioModificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.HasIndex(b => b.PropietarioId);
                t.HasIndex(b => b.PacienteId);
                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                t.HasOne(c => c.UsuarioCreacion)
                   .WithMany()
                   .HasForeignKey(c => c.UsuarioCreacionId)
                   .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(c => c.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(c => c.Paciente)
                  .WithMany(p => p.Citas)
                  .HasForeignKey(c => c.PacienteId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            // ******************************************************************
            // Se define Tabla de Paciente
            // ******************************************************************
            modelBuilder.Entity<Paciente>(t =>
            {
                t.Property(b => b.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.PropietarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.Nombre)
                    .HasColumnType("varchar(128)")
                    .IsRequired();

                t.Property(b => b.Sexo)
                    .HasColumnType("char(1)")
                    .IsRequired();

                t.Property(b => b.Especie)
                    .HasColumnType("varchar(64)")
                    .IsRequired();

                t.Property(b => b.Peso)
                    .HasColumnType("decimal(4,2)")
                    .IsRequired();

                t.Property(b => b.Raza)
                    .HasColumnType("varchar(64)")
                    .IsRequired();

                t.Property(b => b.Color)
                    .HasColumnType("varchar(64)")
                    .IsRequired();

                t.Property(b => b.Edad)
                    .HasColumnType("int")
                    .IsRequired();

                t.Property(b => b.Esterilizado)
                    .HasColumnType("bit")
                    .IsRequired();

                t.Property(b => b.FechaCreacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(b => b.FechaModificacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(b => b.UsuarioCreacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.UsuarioModificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                // Índices para optimizar las búsquedas
                t.HasIndex(b => b.PropietarioId);
                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                // Relaciones con Usuario
                t.HasOne(p => p.UsuarioCreacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioCreacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(p => p.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ******************************************************************
            // Se define Tabla de Medicamento
            // ******************************************************************

            modelBuilder.Entity<Medicamento>(t => 
            {
                t.Property(b => b.MedicamentoId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.FormulaMedicaId).HasColumnType("uniqueidentifier").IsRequired();

                t.Property(b => b.NombreMedicamento).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.Dosis).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.Frecuencia).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.Observaciones).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                //relaciones
                t.HasOne(c => c.UsuarioCreacion)
                 .WithMany()
                 .HasForeignKey(c => c.UsuarioCreacionId)
                 .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(c => c.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            // ******************************************************************
            // Se define Tabla de Cirugia
            // ******************************************************************

            modelBuilder.Entity<Cirugia>(t =>
            {
                t.Property(b => b.CirugiaId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.TipoCirugiaId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.PacienteId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();

                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                t.Property(b => b.Preanestesico).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                t.Property(b => b.Observaciones).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                //relaciones
                t.HasOne(c => c.UsuarioCreacion)
                 .WithMany()
                 .HasForeignKey(c => c.UsuarioCreacionId)
                 .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(c => c.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);


            });

            // ******************************************************************
            // Se define Tabla de TipoCirugia
            // ******************************************************************

            modelBuilder.Entity<Cirugia>(t =>
            {
                t.Property(b => b.TipoCirugiaId).HasColumnType("uniqueidentifier").IsRequired();

                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                //relaciones
                t.HasOne(c => c.UsuarioCreacion)
                 .WithMany()
                 .HasForeignKey(c => c.UsuarioCreacionId)
                 .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(c => c.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);

            });


            // ******************************************************************
            // Se define Tabla de TipoExamen
            // ******************************************************************

            modelBuilder.Entity<TipoExamen>(t =>
            {
                t.Property(b => b.TipoExamenId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(64).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

            });

            // ******************************************************************
            // Se define Tabla de Examen
            // ******************************************************************

            modelBuilder.Entity<Examen>(t =>
            {
                t.Property(b => b.ExamenId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.PacienteId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.TipoExamenId).HasColumnType("uniqueidentifier").IsRequired();

                t.Property(b => b.Fecha).HasColumnType("datetime").IsRequired();
                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                t.Property(b => b.Resultado).HasColumnType("varchar").HasMaxLength(256).IsRequired();
                t.Property(b => b.Observaciones).HasColumnType("varchar").HasMaxLength(512);

                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                // Índices para optimizar las búsquedas
                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);
                t.HasIndex(b => b.PacienteId);
                
                // Relaciones con Usuario
                t.HasOne(p => p.UsuarioCreacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioCreacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(p => p.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);
                //relacion uno a muchos de Tipo Examen
                t.HasOne(p => p.TipoExamen)
                    .WithOne(p => p.Examenes)
                    .HasForeignKey<Examen>(p => p.TipoExamenId)
                    .IsRequired();

            });

            modelBuilder.Entity<TipoVacuna>(t =>
            {
                t.Property(b => b.TipoVacunaId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.Descripcion).HasColumnType("varchar").HasMaxLength(265).IsRequired();
                t.Property(b => b.FechaCreacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaModificacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.UsuarioCreacionId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioModificacionId).HasColumnType("uniqueidentifier").IsRequired();

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

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
            var tarjetaProfesionalParameter = new SqlParameter("@tarjetaProfesional", usuario.TarjetaProfesional ?? (object)DBNull.Value);
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
