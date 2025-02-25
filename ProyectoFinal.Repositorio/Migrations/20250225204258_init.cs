using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TipoCirugia",
                columns: table => new
                {
                    TipoCirugiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCirugia", x => x.TipoCirugiaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    TipoIdentificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.TipoIdentificacionId);
                });

            migrationBuilder.CreateTable(
                name: "TipoVacuna",
                columns: table => new
                {
                    TipoVacunaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(265)", maxLength: 265, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVacuna", x => x.TipoVacunaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoIdentificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    TarjetaProfesional = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Clave = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Salt = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoIdentificacion_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    MedicamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormulaMedicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreMedicamento = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Dosis = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Frecuencia = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.MedicamentoId);
                    table.ForeignKey(
                        name: "FK_Medicamento_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicamento_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoIdentificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.PropietarioId);
                    table.ForeignKey(
                        name: "FK_Propietarios_TipoIdentificacion_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "TipoIdentificacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propietarios_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propietarios_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoExamen",
                columns: table => new
                {
                    TipoExamenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExamen", x => x.TipoExamenId);
                    table.ForeignKey(
                        name: "FK_TipoExamen_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoExamen_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: false),
                    Especie = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Raza = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Esterilizado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Pacientes_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cirugia",
                columns: table => new
                {
                    CirugiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoCirugiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Preanestesico = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cirugia", x => x.CirugiaId);
                    table.ForeignKey(
                        name: "FK_Cirugia_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cirugia_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cirugia_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desparasitaciones",
                columns: table => new
                {
                    DesparasitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesparasitacionTipo = table.Column<string>(type: "varchar", nullable: false),
                    DesparasitacionForma = table.Column<string>(type: "varchar", nullable: false),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaProximaAplicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desparasitaciones", x => x.DesparasitacionId);
                    table.ForeignKey(
                        name: "FK_Desparasitaciones_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desparasitaciones_Pacientes_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desparasitaciones_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desparasitaciones_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Examen",
                columns: table => new
                {
                    ExamenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoExamenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Resultado = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.ExamenId);
                    table.ForeignKey(
                        name: "FK_Examen_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examen_TipoExamen_TipoExamenId",
                        column: x => x.TipoExamenId,
                        principalTable: "TipoExamen",
                        principalColumn: "TipoExamenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examen_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examen_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examen_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacuna",
                columns: table => new
                {
                    VacunaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoVacunaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Laboratorio = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    Lote = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    FechaAplicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaProximaAplicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacuna", x => x.VacunaId);
                    table.ForeignKey(
                        name: "FK_Vacuna_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacuna_TipoVacuna_TipoVacunaId",
                        column: x => x.TipoVacunaId,
                        principalTable: "TipoVacuna",
                        principalColumn: "TipoVacunaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacuna_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacuna_Usuario_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cirugia_PacienteId",
                table: "Cirugia",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cirugia_UsuarioCreacionId",
                table: "Cirugia",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cirugia_UsuarioModificacionId",
                table: "Cirugia",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PropietarioId",
                table: "Citas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioCreacionId",
                table: "Citas",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_UsuarioModificacionId",
                table: "Citas",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Desparasitaciones_PacienteId",
                table: "Desparasitaciones",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Desparasitaciones_PropietarioId",
                table: "Desparasitaciones",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Desparasitaciones_UsuarioCreacionId",
                table: "Desparasitaciones",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Desparasitaciones_UsuarioModificacionId",
                table: "Desparasitaciones",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_PacienteId",
                table: "Examen",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_TipoExamenId",
                table: "Examen",
                column: "TipoExamenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examen_UsuarioCreacionId",
                table: "Examen",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_UsuarioId",
                table: "Examen",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_UsuarioModificacionId",
                table: "Examen",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_UsuarioCreacionId",
                table: "Medicamento",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_UsuarioModificacionId",
                table: "Medicamento",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PropietarioId",
                table: "Pacientes",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UsuarioCreacionId",
                table: "Pacientes",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UsuarioModificacionId",
                table: "Pacientes",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_NumeroIdentificacion",
                table: "Propietarios",
                column: "NumeroIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_TipoIdentificacionId",
                table: "Propietarios",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_UsuarioCreacionId",
                table: "Propietarios",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_UsuarioModificacionId",
                table: "Propietarios",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioCreacionId",
                table: "Rol",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioModificacionId",
                table: "Rol",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoExamen_UsuarioCreacionId",
                table: "TipoExamen",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoExamen_UsuarioModificacionId",
                table: "TipoExamen",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioCreacionId",
                table: "TipoIdentificacion",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioModificacionId",
                table: "TipoIdentificacion",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoVacuna_UsuarioCreacionId",
                table: "TipoVacuna",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoVacuna_UsuarioModificacionId",
                table: "TipoVacuna",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CorreoElectronico",
                table: "Usuario",
                column: "CorreoElectronico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoIdentificacionId",
                table: "Usuario",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioCreacionId",
                table: "Usuario",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioModificacionId",
                table: "Usuario",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_PacienteId",
                table: "Vacuna",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_TipoVacunaId",
                table: "Vacuna",
                column: "TipoVacunaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_UsuarioCreacionId",
                table: "Vacuna",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_UsuarioModificacionId",
                table: "Vacuna",
                column: "UsuarioModificacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cirugia");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Desparasitaciones");

            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "TipoCirugia");

            migrationBuilder.DropTable(
                name: "Vacuna");

            migrationBuilder.DropTable(
                name: "TipoExamen");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "TipoVacuna");

            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");
        }
    }
}
