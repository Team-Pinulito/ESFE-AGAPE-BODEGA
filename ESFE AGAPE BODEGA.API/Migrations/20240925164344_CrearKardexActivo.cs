using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class CrearKardexActivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kardexActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioActivoId = table.Column<int>(type: "int", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    TipoMovimiento = table.Column<byte>(type: "tinyint", nullable: false),
                    Saldo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kardexActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kardexActivos_inventarioActivos_InventarioActivoId",
                        column: x => x.InventarioActivoId,
                        principalTable: "inventarioActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kardexActivos_InventarioActivoId",
                table: "kardexActivos",
                column: "InventarioActivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kardexActivos");
        }
    }
}
