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
                    RolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    TipoIdentificacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.TipoIdentificacionID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoIdentificacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UsuarioCreacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioModificacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoIdentificacion_TipoIdentificacionID",
                        column: x => x.TipoIdentificacionID,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "TipoIdentificacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioCreacionID",
                table: "Rol",
                column: "UsuarioCreacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioModificacionID",
                table: "Rol",
                column: "UsuarioModificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioCreacionID",
                table: "TipoIdentificacion",
                column: "UsuarioCreacionID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioModificacionID",
                table: "TipoIdentificacion",
                column: "UsuarioModificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolID",
                table: "Usuario",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoIdentificacionID",
                table: "Usuario",
                column: "TipoIdentificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioCreacionID",
                table: "Usuario",
                column: "UsuarioCreacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioModificacionID",
                table: "Usuario",
                column: "UsuarioModificacionID");
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
