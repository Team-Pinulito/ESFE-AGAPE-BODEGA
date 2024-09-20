using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ajusteInventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correlativo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    TipoMantenimiento = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ajusteInventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ajusteInventarios_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventarioActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivoId = table.Column<int>(type: "int", nullable: false),
                    EstanteId = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarioActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventarioActivos_activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventarioActivos_estantes_EstanteId",
                        column: x => x.EstanteId,
                        principalTable: "estantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paqueteActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correlativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paqueteActivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AjusteInventarioInventarioActivo",
                columns: table => new
                {
                    AjuesteInventariosId = table.Column<int>(type: "int", nullable: false),
                    InventarioActivosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteInventarioInventarioActivo", x => new { x.AjuesteInventariosId, x.InventarioActivosId });
                    table.ForeignKey(
                        name: "FK_AjusteInventarioInventarioActivo_ajusteInventarios_AjuesteInventariosId",
                        column: x => x.AjuesteInventariosId,
                        principalTable: "ajusteInventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AjusteInventarioInventarioActivo_inventarioActivos_InventarioActivosId",
                        column: x => x.InventarioActivosId,
                        principalTable: "inventarioActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detallePaqueteActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivoId = table.Column<int>(type: "int", nullable: false),
                    PaqueteActivoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePaqueteActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallePaqueteActivos_activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePaqueteActivos_paqueteActivos_PaqueteActivoId",
                        column: x => x.PaqueteActivoId,
                        principalTable: "paqueteActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSolicitudActivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudActivoId = table.Column<int>(type: "int", nullable: false),
                    ActivoId = table.Column<int>(type: "int", nullable: false),
                    PaqueteActivoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSolicitudActivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudActivo_activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitudActivo_paqueteActivos_PaqueteActivoId",
                        column: x => x.PaqueteActivoId,
                        principalTable: "paqueteActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingresoactivos_UsuarioId",
                table: "ingresoactivos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleIngresos_InventarioActivoId",
                table: "detalleIngresos",
                column: "InventarioActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_activos_EstanteId",
                table: "activos",
                column: "EstanteId");

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioInventarioActivo_InventarioActivosId",
                table: "AjusteInventarioInventarioActivo",
                column: "InventarioActivosId");

            migrationBuilder.CreateIndex(
                name: "IX_ajusteInventarios_UsuarioId",
                table: "ajusteInventarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePaqueteActivos_ActivoId",
                table: "detallePaqueteActivos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePaqueteActivos_PaqueteActivoId",
                table: "detallePaqueteActivos",
                column: "PaqueteActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudActivo_ActivoId",
                table: "DetalleSolicitudActivo",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudActivo_PaqueteActivoId",
                table: "DetalleSolicitudActivo",
                column: "PaqueteActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventarioActivos_ActivoId",
                table: "inventarioActivos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventarioActivos_EstanteId",
                table: "inventarioActivos",
                column: "EstanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_activos_estantes_EstanteId",
                table: "activos",
                column: "EstanteId",
                principalTable: "estantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                table: "detalleIngresos",
                column: "InventarioActivoId",
                principalTable: "inventarioActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresoactivos_usuarios_UsuarioId",
                table: "ingresoactivos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activos_estantes_EstanteId",
                table: "activos");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                table: "detalleIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresoactivos_usuarios_UsuarioId",
                table: "ingresoactivos");

            migrationBuilder.DropTable(
                name: "AjusteInventarioInventarioActivo");

            migrationBuilder.DropTable(
                name: "detallePaqueteActivos");

            migrationBuilder.DropTable(
                name: "DetalleSolicitudActivo");

            migrationBuilder.DropTable(
                name: "ajusteInventarios");

            migrationBuilder.DropTable(
                name: "inventarioActivos");

            migrationBuilder.DropTable(
                name: "paqueteActivos");

            migrationBuilder.DropIndex(
                name: "IX_ingresoactivos_UsuarioId",
                table: "ingresoactivos");

            migrationBuilder.DropIndex(
                name: "IX_detalleIngresos_InventarioActivoId",
                table: "detalleIngresos");

            migrationBuilder.DropIndex(
                name: "IX_activos_EstanteId",
                table: "activos");
        }
    }
}
