using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _20240920_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "solicitudActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdBodegueroEntregaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdBodegueroRecibeId = table.Column<int>(type: "int", nullable: false),
                    Correlativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntregaEsperada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRecepcionEsperada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solicitudActivos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_solicitudActivos_usuarios_UsuarioIdBodegueroEntregaId",
                        column: x => x.UsuarioIdBodegueroEntregaId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_solicitudActivos_usuarios_UsuarioIdBodegueroRecibeId",
                        column: x => x.UsuarioIdBodegueroRecibeId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitudActivo_SolicitudActivoId",
                table: "DetalleSolicitudActivo",
                column: "SolicitudActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudActivos_UsuarioId",
                table: "solicitudActivos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudActivos_UsuarioIdBodegueroEntregaId",
                table: "solicitudActivos",
                column: "UsuarioIdBodegueroEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudActivos_UsuarioIdBodegueroRecibeId",
                table: "solicitudActivos",
                column: "UsuarioIdBodegueroRecibeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitudActivo_solicitudActivos_SolicitudActivoId",
                table: "DetalleSolicitudActivo",
                column: "SolicitudActivoId",
                principalTable: "solicitudActivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitudActivo_solicitudActivos_SolicitudActivoId",
                table: "DetalleSolicitudActivo");

            migrationBuilder.DropTable(
                name: "solicitudActivos");

            migrationBuilder.DropIndex(
                name: "IX_DetalleSolicitudActivo_SolicitudActivoId",
                table: "DetalleSolicitudActivo");
        }
    }
}
