using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_roles_RolId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_activos_TipoActivoId",
                table: "activos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_RolId",
                table: "usuarios",
                newName: "IX_usuarios_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_activos_TipoActivoId",
                table: "activos",
                column: "TipoActivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_RolId",
                table: "usuarios",
                column: "RolId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_RolId",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_activos_TipoActivoId",
                table: "activos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_RolId",
                table: "Usuario",
                newName: "IX_Usuario_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_activos_TipoActivoId",
                table: "activos",
                column: "TipoActivoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_roles_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
