using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _24092024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitudActivo_activos_ActivoId",
                table: "DetalleSolicitudActivo");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitudActivo_paqueteActivos_PaqueteActivoId",
                table: "DetalleSolicitudActivo");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitudActivo_solicitudActivos_SolicitudActivoId",
                table: "DetalleSolicitudActivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleSolicitudActivo",
                table: "DetalleSolicitudActivo");

            migrationBuilder.RenameTable(
                name: "DetalleSolicitudActivo",
                newName: "detalleSolicitudActivos");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleSolicitudActivo_SolicitudActivoId",
                table: "detalleSolicitudActivos",
                newName: "IX_detalleSolicitudActivos_SolicitudActivoId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleSolicitudActivo_PaqueteActivoId",
                table: "detalleSolicitudActivos",
                newName: "IX_detalleSolicitudActivos_PaqueteActivoId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleSolicitudActivo_ActivoId",
                table: "detalleSolicitudActivos",
                newName: "IX_detalleSolicitudActivos_ActivoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleSolicitudActivos",
                table: "detalleSolicitudActivos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleSolicitudActivos_activos_ActivoId",
                table: "detalleSolicitudActivos",
                column: "ActivoId",
                principalTable: "activos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleSolicitudActivos_paqueteActivos_PaqueteActivoId",
                table: "detalleSolicitudActivos",
                column: "PaqueteActivoId",
                principalTable: "paqueteActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleSolicitudActivos_solicitudActivos_SolicitudActivoId",
                table: "detalleSolicitudActivos",
                column: "SolicitudActivoId",
                principalTable: "solicitudActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleSolicitudActivos_activos_ActivoId",
                table: "detalleSolicitudActivos");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleSolicitudActivos_paqueteActivos_PaqueteActivoId",
                table: "detalleSolicitudActivos");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleSolicitudActivos_solicitudActivos_SolicitudActivoId",
                table: "detalleSolicitudActivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleSolicitudActivos",
                table: "detalleSolicitudActivos");

            migrationBuilder.RenameTable(
                name: "detalleSolicitudActivos",
                newName: "DetalleSolicitudActivo");

            migrationBuilder.RenameIndex(
                name: "IX_detalleSolicitudActivos_SolicitudActivoId",
                table: "DetalleSolicitudActivo",
                newName: "IX_DetalleSolicitudActivo_SolicitudActivoId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleSolicitudActivos_PaqueteActivoId",
                table: "DetalleSolicitudActivo",
                newName: "IX_DetalleSolicitudActivo_PaqueteActivoId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleSolicitudActivos_ActivoId",
                table: "DetalleSolicitudActivo",
                newName: "IX_DetalleSolicitudActivo_ActivoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleSolicitudActivo",
                table: "DetalleSolicitudActivo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitudActivo_activos_ActivoId",
                table: "DetalleSolicitudActivo",
                column: "ActivoId",
                principalTable: "activos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitudActivo_paqueteActivos_PaqueteActivoId",
                table: "DetalleSolicitudActivo",
                column: "PaqueteActivoId",
                principalTable: "paqueteActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitudActivo_solicitudActivos_SolicitudActivoId",
                table: "DetalleSolicitudActivo",
                column: "SolicitudActivoId",
                principalTable: "solicitudActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
