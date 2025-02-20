﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Repositorio;

#nullable disable

namespace ProyectoFinal.Repositorio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoFinal.Entidades.Cirugia", b =>
                {
                    b.Property<Guid>("CirugiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Preanestesico")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<Guid>("TipoCirugiaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CirugiaId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Cirugia", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Cita", b =>
                {
                    b.Property<Guid>("CitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropietarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CitaId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PropietarioId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Examen", b =>
                {
                    b.Property<Guid>("ExamenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(512)
                        .HasColumnType("varchar");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<Guid>("TipoExamenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamenId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("TipoExamenId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Examen");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Medicamento", b =>
                {
                    b.Property<Guid>("MedicamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dosis")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<Guid>("FormulaMedicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Frecuencia")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("NombreMedicamento")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MedicamentoId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Medicamento", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Paciente", b =>
                {
                    b.Property<Guid>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<bool>("Esterilizado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(4,2)");

                    b.Property<Guid>("PropietarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Raza")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PacienteId");

                    b.HasIndex("PropietarioId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Rol", b =>
                {
                    b.Property<Guid>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.TipoCirugia", b =>
                {
                    b.Property<Guid>("TipoCirugiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TipoCirugiaId");

                    b.ToTable("TipoCirugia", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.TipoExamen", b =>
                {
                    b.Property<Guid>("TipoExamenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TipoExamenId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("TipoExamen", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.TipoIdentificacion", b =>
                {
                    b.Property<Guid>("TipoIdentificacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TipoIdentificacionId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("TipoIdentificacion", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar");

                    b.Property<string>("TarjetaProfesional")
                        .HasMaxLength(64)
                        .HasColumnType("varchar");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar");

                    b.Property<Guid>("TipoIdentificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioCreacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioModificacionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CorreoElectronico")
                        .IsUnique();

                    b.HasIndex("RolId");

                    b.HasIndex("TipoIdentificacionId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Cirugia", b =>
                {
                    b.HasOne("ProyectoFinal.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Cita", b =>
                {
                    b.HasOne("ProyectoFinal.Entidades.Paciente", "Paciente")
                        .WithMany("Citas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Examen", b =>
                {
                    b.HasOne("ProyectoFinal.Entidades.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.TipoExamen", "TipoExamen")
                        .WithMany("Examen")
                        .HasForeignKey("TipoExamenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("TipoExamen");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Medicamento", b =>
                {
                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Paciente", b =>
                {
                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Usuario", b =>
                {
                    b.HasOne("ProyectoFinal.Entidades.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Entidades.TipoIdentificacion", "TipoIdentificacion")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoIdentificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("TipoIdentificacion");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Paciente", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.TipoExamen", b =>
                {
                    b.Navigation("Examen");
                });

            modelBuilder.Entity("ProyectoFinal.Entidades.TipoIdentificacion", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
