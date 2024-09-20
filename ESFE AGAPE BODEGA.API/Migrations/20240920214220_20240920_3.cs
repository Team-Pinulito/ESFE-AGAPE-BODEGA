using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _20240920_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solicitudActivos_usuarios_UsuarioId",
                table: "solicitudActivos");

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudActivos_usuarios_UsuarioId",
                table: "solicitudActivos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_solicitudActivos_usuarios_UsuarioId",
                table: "solicitudActivos");

            migrationBuilder.AddForeignKey(
                name: "FK_solicitudActivos_usuarios_UsuarioId",
                table: "solicitudActivos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
