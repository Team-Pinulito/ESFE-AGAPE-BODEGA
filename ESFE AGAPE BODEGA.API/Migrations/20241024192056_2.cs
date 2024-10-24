using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "correlativos");

            migrationBuilder.AddColumn<bool>(
                name: "Estatus",
                table: "usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ActivoId",
                table: "detalleIngresos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "detalleIngresos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstanteId",
                table: "detalleIngresos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_detalleIngresos_ActivoId",
                table: "detalleIngresos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleIngresos_BodegaId",
                table: "detalleIngresos",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleIngresos_EstanteId",
                table: "detalleIngresos",
                column: "EstanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleIngresos_activos_ActivoId",
                table: "detalleIngresos",
                column: "ActivoId",
                principalTable: "activos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleIngresos_bodegas_BodegaId",
                table: "detalleIngresos",
                column: "BodegaId",
                principalTable: "bodegas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleIngresos_estantes_EstanteId",
                table: "detalleIngresos",
                column: "EstanteId",
                principalTable: "estantes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleIngresos_activos_ActivoId",
                table: "detalleIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleIngresos_bodegas_BodegaId",
                table: "detalleIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleIngresos_estantes_EstanteId",
                table: "detalleIngresos");

            migrationBuilder.DropIndex(
                name: "IX_detalleIngresos_ActivoId",
                table: "detalleIngresos");

            migrationBuilder.DropIndex(
                name: "IX_detalleIngresos_BodegaId",
                table: "detalleIngresos");

            migrationBuilder.DropIndex(
                name: "IX_detalleIngresos_EstanteId",
                table: "detalleIngresos");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "ActivoId",
                table: "detalleIngresos");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "detalleIngresos");

            migrationBuilder.DropColumn(
                name: "EstanteId",
                table: "detalleIngresos");

            migrationBuilder.CreateTable(
                name: "correlativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AliasFinal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliasInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_correlativos", x => x.Id);
                });
        }
    }
}
