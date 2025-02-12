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
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");
        }
    }
}
