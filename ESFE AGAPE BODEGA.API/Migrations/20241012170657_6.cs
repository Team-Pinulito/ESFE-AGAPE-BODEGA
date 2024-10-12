using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                table: "detalleIngresos");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioActivoId",
                table: "detalleIngresos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                table: "detalleIngresos",
                column: "InventarioActivoId",
                principalTable: "inventarioActivos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                table: "detalleIngresos");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioActivoId",
                table: "detalleIngresos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                table: "detalleIngresos",
                column: "InventarioActivoId",
                principalTable: "inventarioActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
