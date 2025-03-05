using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;

namespace ProyectoFinal.Repositorio
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Cita> Citas { get; set; }
       
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Cirugia> Cirugias { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Desparasitacion> Desparasitaciones { get; set; }        
        public DbSet<TipoVacuna> TipoVacunas { get; set; }
        public DbSet<TipoCirugia> TipoCirugias { get; set; }
        public DbSet<TipoExamen> TipoExamenes { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }

        public DbSet<FormulaMedica> FormulasMedicas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<FormulaMedicaMedicamento> FormulaMedicaMedicamentos { get; set; }
        public DbSet<TipoImagenDiagnostica> TipoImagenesDiagnosticas { get; set; }
        public DbSet<ImagenDiagnostica> ImagenesDiagnosticas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Definicion de nombres de las tablas
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<TipoIdentificacion>().ToTable("TipoIdentificacion");
            modelBuilder.Entity<Cirugia>().ToTable("Cirugia");
            modelBuilder.Entity<Examen>().ToTable("Examen");
            modelBuilder.Entity<TipoCirugia>().ToTable("TipoCirugia");
            modelBuilder.Entity<TipoExamen>().ToTable("TipoExamen");
            modelBuilder.Entity<TipoVacuna>().ToTable("TipoVacuna");
            modelBuilder.Entity<Vacuna>().ToTable("Vacuna");
            modelBuilder.Entity<TipoImagenDiagnostica>().ToTable("TipoImagenDiagnostica");
            modelBuilder.Entity<ImagenDiagnostica>().ToTable("ImagenDiagnostica");


            modelBuilder.Entity<FormulaMedica>().ToTable("FormulaMedica");
            modelBuilder.Entity<Medicamento>().ToTable("Medicamento");
            modelBuilder.Entity<FormulaMedicaMedicamento>().ToTable("FormulaMedicaMedicamento");

            modelBuilder.Entity<Consulta>().ToTable("Consulta");
            modelBuilder.Entity<Cita>().ToTable("Cita");


            // ******************************************************************
            // Se define Tabla de Usuarios
            // ******************************************************************

            modelBuilder.Entity<Usuario>(t =>
            {
                t.Property(b => b.NumeroIdentificacion)
                    .HasColumnType("varchar")
                    .HasMaxLength(16)
                    .IsRequired();

                t.Property(b => b.Nombre)
                    .HasColumnType("varchar")
                    .HasMaxLength(128)
                    .IsRequired();

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

                t.Property(b => b.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.Motivo)
                    .HasColumnType("varchar")
                    .HasMaxLength(256);

                t.Property(b => b.Estado)
                    .HasColumnType("varchar")
                    .HasMaxLength(32)
                    .HasConversion<string>()
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

                t.HasIndex(b => b.PacienteId);
                t.HasIndex(b => b.UsuarioId);
                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                t.HasOne(c => c.Usuario)
                    .WithMany()
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

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
                // Propiedades de la entidad Paciente
                t.Property(b => b.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.PropietarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.Nombre)
                    .HasColumnType("varchar")
                    .HasMaxLength(128)
                    .IsRequired();

                t.Property(b => b.Sexo)
                    .HasColumnType("char")
                    .IsRequired();

                t.Property(b => b.Especie)
                    .HasColumnType("varchar")
                    .HasMaxLength(64)
                    .IsRequired();

                t.Property(b => b.Peso)
                    .HasColumnType("decimal")
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


                t.HasIndex(b => b.PropietarioId);
                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);

                t.HasOne(p => p.UsuarioCreacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioCreacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(p => p.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(p => p.Propietario)
                    .WithMany()
                    .HasForeignKey(p => p.PropietarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasMany(p => p.Citas)
                    .WithOne(c => c.Paciente)
                    .HasForeignKey(c => c.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasMany(p => p.Desparasitaciones)
                    .WithOne(d => d.Paciente)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            // ******************************************************************
            // Se define Tabla de Medicamento
            // ******************************************************************
            modelBuilder.Entity<Medicamento>(t =>
            {
                t.Property(m => m.MedicamentoId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                t.Property(m => m.UsuarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(m => m.NombreMedicamento)
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();

                t.Property(m => m.Dosis)
                    .HasColumnType("varchar")
                    .HasMaxLength(128)
                    .IsRequired();

                t.Property(m => m.Frecuencia)
                    .HasColumnType("varchar")
                    .HasMaxLength(128)
                    .IsRequired();

                t.Property(m => m.Observaciones)
                    .HasColumnType("varchar")
                    .HasMaxLength(256);

                t.Property(m => m.FechaCreacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(m => m.FechaModificacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(m => m.UsuarioCreacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(m => m.UsuarioModificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.HasIndex(m => m.UsuarioId);
                t.HasIndex(m => m.UsuarioCreacionId);
                t.HasIndex(m => m.UsuarioModificacionId);

                t.HasOne(m => m.UsuarioCreacion)
                    .WithMany()
                    .HasForeignKey(m => m.UsuarioCreacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(m => m.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(m => m.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ******************************************************************
            // Se define Tabla de FormulaMedica
            // ******************************************************************
            modelBuilder.Entity<FormulaMedica>(t =>
            {
                t.Property(f => f.FormulaMedicaId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(f => f.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(f => f.UsuarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(f => f.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(f => f.Observaciones)
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                t.Property(f => f.UsuarioCreacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(f => f.UsuarioModificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.HasIndex(f => f.PacienteId);
                t.HasIndex(f => f.UsuarioCreacionId);
                t.HasIndex(f => f.UsuarioModificacionId);

                t.HasOne(f => f.Paciente)
                    .WithMany()
                    .HasForeignKey(f => f.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(f => f.Usuario)
                    .WithMany()
                    .HasForeignKey(f => f.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(f => f.UsuarioCreacion)
                    .WithMany()
                    .HasForeignKey(f => f.UsuarioCreacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(f => f.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(f => f.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ******************************************************************
            // Se define Tabla de Relación Muchos a Muchos: FormulaMedicaMedicamento
            // ******************************************************************
            modelBuilder.Entity<FormulaMedicaMedicamento>(t =>
            {
                t.HasKey(fm => new { fm.FormulaMedicaId, fm.MedicamentoId });

                t.HasOne(fm => fm.FormulaMedica)
                    .WithMany(f => f.FormulaMedicaMedicamentos)
                    .HasForeignKey(fm => fm.FormulaMedicaId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(fm => fm.Medicamento)
                    .WithMany(m => m.FormulaMedicaMedicamentos)
                    .HasForeignKey(fm => fm.MedicamentoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            // ******************************************************************
            // Se define Tabla de Cirugia
            // ******************************************************************
            modelBuilder.Entity<Cirugia>(t =>
            {
                t.Property(b => b.CirugiaId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.TipoCirugiaId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.UsuarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.Descripcion)
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();

                t.Property(b => b.Preanestesico)
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();

                t.Property(b => b.Observaciones)
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
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


                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);
                

                t.HasOne(c => c.Paciente)
                    .WithMany()
                    .HasForeignKey(c => c.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(c => c.TipoCirugia)
                    .WithMany()
                    .HasForeignKey(c => c.TipoCirugiaId)
                    .OnDelete(DeleteBehavior.Restrict);

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
            modelBuilder.Entity<TipoCirugia>(t =>
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
                t.Property(b => b.TipoExamenId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();
                t.Property(b => b.Descripcion)
                    .HasColumnType("varchar")
                    .HasMaxLength(64)
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

            // ******************************************************************re
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
                //relacion con paciente (un pciente puede tener varios examnes)
                t.HasOne(c => c.Paciente)
                  .WithMany(p => p.Examenes)
                  .HasForeignKey(c => c.PacienteId)
                  .OnDelete(DeleteBehavior.Restrict);

            });
            
            // ******************************************************************
            // Se define Tabla de TipoVacuna
            // ******************************************************************
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
            // *****************************************************************
            // Se define Tabla de Vacuna
            // *****************************************************************
            modelBuilder.Entity<Vacuna>(t =>
            {
                t.Property(b => b.VacunaId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.PacienteId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.TipoVacunaId).HasColumnType("uniqueidentifier").IsRequired();

                t.Property(b => b.Laboratorio).HasColumnType("varchar").HasMaxLength(32);
                t.Property(b => b.Lote).HasColumnType("varchar").HasMaxLength(64);
                t.Property(b => b.FechaAplicacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.FechaProximaAplicacion).HasColumnType("datetime").IsRequired();
                t.Property(b => b.Observaciones).HasColumnType("varchar").HasMaxLength(256);

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


                //relacion uno a muchos de TipoVacuna
                t.HasOne(p => p.TipoVacuna)
                    .WithOne(p => p.Vacuna)
                    .HasForeignKey<Vacuna>(p => p.TipoVacunaId)
                    .IsRequired();
                //relacion con paciente (un pciente puede tener varias vacuna) de uno a muchos
                t.HasOne(c => c.Paciente)
                  .WithMany(p => p.Vacunas)
                  .HasForeignKey(c => c.PacienteId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            // ******************************************************************
            // Se define Tabla de Desparacitación
            // ******************************************************************
            modelBuilder.Entity<Desparasitacion>(t =>
            {
                // Propiedades de la entidad Desparasitacion
                t.Property(b => b.DesparasitacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.DesparasitacionTipo)
                    .HasColumnType("varchar")
                    .HasMaxLength(32)
                    .HasConversion<string>()
                    .IsRequired();

                t.Property(b => b.DesparasitacionForma)
                    .HasColumnType("varchar")
                    .HasMaxLength(32)
                    .HasConversion<string>()
                    .IsRequired();

                t.Property(b => b.FechaAplicacion)
                    .HasColumnType("datetime")
                    .IsRequired();
                t.Property(b => b.FechaProximaAplicacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(b => b.Observaciones)
                    .HasColumnType("varchar")
                    .HasMaxLength(512);

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
                    .HasColumnType("uniqueidentifier").IsRequired();

                // Índices para optimizar las búsquedas
                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);
                t.HasIndex(b => b.PacienteId);
                
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
            // Se define Tabla de Propietario
            // ******************************************************************
            modelBuilder.Entity<Propietario>(t =>
            {
                t.Property(b => b.PropietarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.TipoIdentificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(b => b.NumeroIdentificacion)
                    .HasColumnType("varchar")
                    .HasMaxLength(16)
                    .IsRequired();

                t.Property(b => b.Nombre)
                    .HasColumnType("varchar")
                    .HasMaxLength(128)
                    .IsRequired();

                t.Property(b => b.Apellido)
                    .HasColumnType("varchar")
                    .HasMaxLength(128);

                t.Property(b => b.Telefono)
                    .HasColumnType("varchar")
                    .HasMaxLength(16);

                t.Property(b => b.CorreoElectronico)
                    .HasColumnType("varchar")
                    .HasMaxLength(128);

                t.Property(b => b.Direccion)
                    .HasColumnType("varchar")
                    .HasMaxLength(128);

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

                t.HasIndex(b => b.UsuarioCreacionId);
                t.HasIndex(b => b.UsuarioModificacionId);
                t.HasIndex(b => b.TipoIdentificacionId);
                t.HasIndex(b => b.NumeroIdentificacion);

                
                t.HasOne(p => p.UsuarioCreacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioCreacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(p => p.UsuarioModificacion)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioModificacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(p => p.TipoIdentificacion)
                    .WithMany()
                    .HasForeignKey(p => p.TipoIdentificacionId)
                    .OnDelete(DeleteBehavior.Restrict);

                t.HasMany(p => p.Pacientes)
                    .WithOne(p => p.Propietario)
                    .HasForeignKey(p => p.PropietarioId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

          

            // ******************************************************************
            // Se define Tabla de Consulta
            // ******************************************************************
            modelBuilder.Entity<Consulta>(t =>
            {
                t.Property(c => c.ConsultaId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                t.Property(c => c.PacienteId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(c => c.UsuarioId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();
        
                t.Property(c => c.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(c => c.Motivo)
                    .HasColumnType("varchar")
                    .HasMaxLength(256);

                t.Property(c => c.Sintomas)
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();

                t.Property(c => c.Diagnostico)
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();

                t.Property(c => c.FechaCreacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(c => c.FechaModificacion)
                    .HasColumnType("datetime")
                    .IsRequired();

                t.Property(c => c.UsuarioCreacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.Property(c => c.UsuarioModificacionId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                t.HasIndex(c => c.PacienteId);
                t.HasIndex(c => c.UsuarioCreacionId);
                t.HasIndex(c => c.UsuarioModificacionId);

                t.HasOne(c => c.Paciente)
                    .WithMany()
                    .HasForeignKey(c => c.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

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
            // Se define Tabla de TipoImagenDiagnostica
            // ******************************************************************
            modelBuilder.Entity<TipoImagenDiagnostica>(t =>
            {
                t.Property(b => b.TipoImagenDiagnosticaId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();
                t.Property(b => b.Descripcion)
                    .HasColumnType("varchar")
                    .HasMaxLength(64)
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

            // ******************************************************************re
            // Se define Tabla de ImagenDiagnostica
            // ******************************************************************
            modelBuilder.Entity<ImagenDiagnostica>(t =>
            {
                t.Property(b => b.ImagenDiagnosticaId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.PacienteId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();
                t.Property(b => b.TipoImagenDiagnosticaId).HasColumnType("uniqueidentifier").IsRequired();

                t.Property(b => b.Fecha).HasColumnType("datetime").IsRequired();
                t.Property(b => b.SignosClinicos).HasColumnType("varchar").HasMaxLength(128).IsRequired();
                t.Property(b => b.Imagen).HasColumnType("varbinary(max)").IsRequired();
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
                //relacion uno a muchos (Un TipoImagenesDiagnosticas puede tener muchas ImagenesDiagnosticas)
                t.HasOne(p => p.TipoImagenDiagnostica)
                    .WithMany(p => p.ImagenesDiagnosticas)
                    .HasForeignKey(c => c.TipoImagenDiagnosticaId)
                    .IsRequired();
                //relacion con paciente (un pciente puede tener varias ImagenesDiagnosticas)
                t.HasOne(c => c.Paciente)
                  .WithMany(p => p.ImagenesDiagnosticas)
                  .HasForeignKey(c => c.PacienteId)
                  .OnDelete(DeleteBehavior.Restrict);

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
            var nombreParameter = new SqlParameter("@nombre", usuario.Nombre );
            var apellidoParameter = new SqlParameter("@apellido", usuario.Apellido ?? (object)DBNull.Value);
            var telefonoParameter = new SqlParameter("@telefono", usuario.Telefono ?? (object)DBNull.Value);
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
