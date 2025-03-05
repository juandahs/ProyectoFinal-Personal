using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    CitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Estado = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.CitaId);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Sintomas = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Diagnostico = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ConsultaId);
                });

            migrationBuilder.CreateTable(
                name: "Desparasitaciones",
                columns: table => new
                {
                    DesparasitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesparasitacionTipo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    DesparasitacionForma = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "FormulaMedica",
                columns: table => new
                {
                    FormulaMedicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaMedica", x => x.FormulaMedicaId);
                });

            migrationBuilder.CreateTable(
                name: "FormulaMedicaMedicamento",
                columns: table => new
                {
                    FormulaMedicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaMedicaMedicamento", x => new { x.FormulaMedicaId, x.MedicamentoId });
                    table.ForeignKey(
                        name: "FK_FormulaMedicaMedicamento_FormulaMedica_FormulaMedicaId",
                        column: x => x.FormulaMedicaId,
                        principalTable: "FormulaMedica",
                        principalColumn: "FormulaMedicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagenDiagnostica",
                columns: table => new
                {
                    ImagenDiagnosticaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoImagenDiagnosticaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    SignosClinicos = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    DiagnosticoPresuntivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenDiagnostica", x => x.ImagenDiagnosticaId);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    MedicamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreMedicamento = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Dosis = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Frecuencia = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.MedicamentoId);
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
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoIdentificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "TipoCirugia",
                columns: table => new
                {
                    TipoCirugiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCirugia", x => x.TipoCirugiaId);
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
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCreacionUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioModificacionUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.TipoIdentificacionId);
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
                    Apellido = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
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
                name: "TipoImagenDiagnostica",
                columns: table => new
                {
                    TipoImagenDiagnosticaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoImagenDiagnostica", x => x.TipoImagenDiagnosticaId);
                    table.ForeignKey(
                        name: "FK_TipoImagenDiagnostica_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoImagenDiagnostica_Usuario_UsuarioModificacionId",
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
                        name: "FK_Vacuna_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Cirugia_TipoCirugiaId",
                table: "Cirugia",
                column: "TipoCirugiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cirugia_UsuarioCreacionId",
                table: "Cirugia",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cirugia_UsuarioModificacionId",
                table: "Cirugia",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_UsuarioCreacionId",
                table: "Cita",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_UsuarioId",
                table: "Cita",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_UsuarioModificacionId",
                table: "Cita",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_UsuarioCreacionId",
                table: "Consulta",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_UsuarioModificacionId",
                table: "Consulta",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Desparasitaciones_PacienteId",
                table: "Desparasitaciones",
                column: "PacienteId");

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
                name: "IX_FormulaMedica_PacienteId",
                table: "FormulaMedica",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedica_UsuarioCreacionId",
                table: "FormulaMedica",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedica_UsuarioId",
                table: "FormulaMedica",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedica_UsuarioModificacionId",
                table: "FormulaMedica",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedicaMedicamento_MedicamentoId",
                table: "FormulaMedicaMedicamento",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenDiagnostica_PacienteId",
                table: "ImagenDiagnostica",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenDiagnostica_TipoImagenDiagnosticaId",
                table: "ImagenDiagnostica",
                column: "TipoImagenDiagnosticaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenDiagnostica_UsuarioCreacionId",
                table: "ImagenDiagnostica",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenDiagnostica_UsuarioId",
                table: "ImagenDiagnostica",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenDiagnostica_UsuarioModificacionId",
                table: "ImagenDiagnostica",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_UsuarioCreacionId",
                table: "Medicamento",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_UsuarioId",
                table: "Medicamento",
                column: "UsuarioId");

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
                name: "IX_TipoCirugia_UsuarioCreacionId",
                table: "TipoCirugia",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCirugia_UsuarioModificacionId",
                table: "TipoCirugia",
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
                name: "IX_TipoIdentificacion_UsuarioCreacionUsuarioId",
                table: "TipoIdentificacion",
                column: "UsuarioCreacionUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioModificacionId",
                table: "TipoIdentificacion",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioModificacionUsuarioId",
                table: "TipoIdentificacion",
                column: "UsuarioModificacionUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoImagenDiagnostica_UsuarioCreacionId",
                table: "TipoImagenDiagnostica",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoImagenDiagnostica_UsuarioModificacionId",
                table: "TipoImagenDiagnostica",
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
                name: "IX_Vacuna_UsuarioId",
                table: "Vacuna",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_UsuarioModificacionId",
                table: "Vacuna",
                column: "UsuarioModificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cirugia_Pacientes_PacienteId",
                table: "Cirugia",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cirugia_TipoCirugia_TipoCirugiaId",
                table: "Cirugia",
                column: "TipoCirugiaId",
                principalTable: "TipoCirugia",
                principalColumn: "TipoCirugiaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cirugia_Usuario_UsuarioCreacionId",
                table: "Cirugia",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cirugia_Usuario_UsuarioModificacionId",
                table: "Cirugia",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Pacientes_PacienteId",
                table: "Cita",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Usuario_UsuarioCreacionId",
                table: "Cita",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Usuario_UsuarioId",
                table: "Cita",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Usuario_UsuarioModificacionId",
                table: "Cita",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Pacientes_PacienteId",
                table: "Consulta",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Usuario_UsuarioCreacionId",
                table: "Consulta",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Usuario_UsuarioModificacionId",
                table: "Consulta",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Desparasitaciones_Pacientes_PacienteId",
                table: "Desparasitaciones",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Desparasitaciones_Usuario_UsuarioCreacionId",
                table: "Desparasitaciones",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Desparasitaciones_Usuario_UsuarioModificacionId",
                table: "Desparasitaciones",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Pacientes_PacienteId",
                table: "Examen",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_TipoExamen_TipoExamenId",
                table: "Examen",
                column: "TipoExamenId",
                principalTable: "TipoExamen",
                principalColumn: "TipoExamenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Usuario_UsuarioCreacionId",
                table: "Examen",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Usuario_UsuarioId",
                table: "Examen",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Usuario_UsuarioModificacionId",
                table: "Examen",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormulaMedica_Pacientes_PacienteId",
                table: "FormulaMedica",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormulaMedica_Usuario_UsuarioCreacionId",
                table: "FormulaMedica",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormulaMedica_Usuario_UsuarioId",
                table: "FormulaMedica",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormulaMedica_Usuario_UsuarioModificacionId",
                table: "FormulaMedica",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormulaMedicaMedicamento_Medicamento_MedicamentoId",
                table: "FormulaMedicaMedicamento",
                column: "MedicamentoId",
                principalTable: "Medicamento",
                principalColumn: "MedicamentoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenDiagnostica_Pacientes_PacienteId",
                table: "ImagenDiagnostica",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenDiagnostica_TipoImagenDiagnostica_TipoImagenDiagnosticaId",
                table: "ImagenDiagnostica",
                column: "TipoImagenDiagnosticaId",
                principalTable: "TipoImagenDiagnostica",
                principalColumn: "TipoImagenDiagnosticaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenDiagnostica_Usuario_UsuarioCreacionId",
                table: "ImagenDiagnostica",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenDiagnostica_Usuario_UsuarioId",
                table: "ImagenDiagnostica",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenDiagnostica_Usuario_UsuarioModificacionId",
                table: "ImagenDiagnostica",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Usuario_UsuarioCreacionId",
                table: "Medicamento",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Usuario_UsuarioId",
                table: "Medicamento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Usuario_UsuarioModificacionId",
                table: "Medicamento",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Propietarios_PropietarioId",
                table: "Pacientes",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "PropietarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Usuario_UsuarioCreacionId",
                table: "Pacientes",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Usuario_UsuarioModificacionId",
                table: "Pacientes",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propietarios_TipoIdentificacion_TipoIdentificacionId",
                table: "Propietarios",
                column: "TipoIdentificacionId",
                principalTable: "TipoIdentificacion",
                principalColumn: "TipoIdentificacionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propietarios_Usuario_UsuarioCreacionId",
                table: "Propietarios",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propietarios_Usuario_UsuarioModificacionId",
                table: "Propietarios",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCirugia_Usuario_UsuarioCreacionId",
                table: "TipoCirugia",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCirugia_Usuario_UsuarioModificacionId",
                table: "TipoCirugia",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoExamen_Usuario_UsuarioCreacionId",
                table: "TipoExamen",
                column: "UsuarioCreacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoExamen_Usuario_UsuarioModificacionId",
                table: "TipoExamen",
                column: "UsuarioModificacionId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoIdentificacion_Usuario_UsuarioCreacionUsuarioId",
                table: "TipoIdentificacion",
                column: "UsuarioCreacionUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoIdentificacion_Usuario_UsuarioModificacionUsuarioId",
                table: "TipoIdentificacion",
                column: "UsuarioModificacionUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoIdentificacion_Usuario_UsuarioCreacionUsuarioId",
                table: "TipoIdentificacion");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoIdentificacion_Usuario_UsuarioModificacionUsuarioId",
                table: "TipoIdentificacion");

            migrationBuilder.DropTable(
                name: "Cirugia");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Desparasitaciones");

            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "FormulaMedicaMedicamento");

            migrationBuilder.DropTable(
                name: "ImagenDiagnostica");

            migrationBuilder.DropTable(
                name: "Vacuna");

            migrationBuilder.DropTable(
                name: "TipoCirugia");

            migrationBuilder.DropTable(
                name: "TipoExamen");

            migrationBuilder.DropTable(
                name: "FormulaMedica");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "TipoImagenDiagnostica");

            migrationBuilder.DropTable(
                name: "TipoVacuna");

            migrationBuilder.DropTable(
                name: "Pacientes");

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
