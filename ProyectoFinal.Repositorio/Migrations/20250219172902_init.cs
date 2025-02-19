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
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(128)", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: false),
                    Especie = table.Column<string>(type: "varchar(64)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Raza = table.Column<string>(type: "varchar(64)", nullable: false),
                    Color = table.Column<string>(type: "varchar(64)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Esterilizado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_UsuarioModificacionId",
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
                        name: "FK_Cirugia_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
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
                        name: "FK_Citas_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Medicamento_UsuarioCreacionId",
                table: "Medicamento",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_UsuarioModificacionId",
                table: "Medicamento",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PropietarioId",
                table: "Paciente",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_UsuarioCreacionId",
                table: "Paciente",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_UsuarioModificacionId",
                table: "Paciente",
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
                name: "IX_TipoIdentificacion_UsuarioCreacionId",
                table: "TipoIdentificacion",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioModificacionId",
                table: "TipoIdentificacion",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cirugia");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "TipoCirugia");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");
        }
    }
}
