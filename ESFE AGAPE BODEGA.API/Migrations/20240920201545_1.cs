using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bodegas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodegas", x => x.Id);
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
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipoActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoActivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodegaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estantes_bodegas_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "bodegas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_RolId",
                        column: x => x.RolId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstanteId = table.Column<int>(type: "int", nullable: false),
                    TipoActivoId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoBarra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activos_estantes_EstanteId",
                        column: x => x.EstanteId,
                        principalTable: "estantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_activos_tipoActivos_TipoActivoId",
                        column: x => x.TipoActivoId,
                        principalTable: "tipoActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ingresoactivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correlativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocRelacionado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresoactivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingresoactivos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_inventarioActivos_estantes_EstanteId",
                        column: x => x.EstanteId,
                        principalTable: "estantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "detalleIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngresoActivoId = table.Column<int>(type: "int", nullable: false),
                    InventarioActivoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleIngresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleIngresos_ingresoactivos_IngresoActivoId",
                        column: x => x.IngresoActivoId,
                        principalTable: "ingresoactivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleIngresos_inventarioActivos_InventarioActivoId",
                        column: x => x.InventarioActivoId,
                        principalTable: "inventarioActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activos_EstanteId",
                table: "activos",
                column: "EstanteId");

            migrationBuilder.CreateIndex(
                name: "IX_activos_TipoActivoId",
                table: "activos",
                column: "TipoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioInventarioActivo_InventarioActivosId",
                table: "AjusteInventarioInventarioActivo",
                column: "InventarioActivosId");

            migrationBuilder.CreateIndex(
                name: "IX_ajusteInventarios_UsuarioId",
                table: "ajusteInventarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleIngresos_IngresoActivoId",
                table: "detalleIngresos",
                column: "IngresoActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleIngresos_InventarioActivoId",
                table: "detalleIngresos",
                column: "InventarioActivoId");

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
                name: "IX_estantes_BodegaId",
                table: "estantes",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_ingresoactivos_UsuarioId",
                table: "ingresoactivos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_inventarioActivos_ActivoId",
                table: "inventarioActivos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventarioActivos_EstanteId",
                table: "inventarioActivos",
                column: "EstanteId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RolId",
                table: "usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteInventarioInventarioActivo");

            migrationBuilder.DropTable(
                name: "detalleIngresos");

            migrationBuilder.DropTable(
                name: "detallePaqueteActivos");

            migrationBuilder.DropTable(
                name: "DetalleSolicitudActivo");

            migrationBuilder.DropTable(
                name: "ajusteInventarios");

            migrationBuilder.DropTable(
                name: "ingresoactivos");

            migrationBuilder.DropTable(
                name: "inventarioActivos");

            migrationBuilder.DropTable(
                name: "paqueteActivos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "activos");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "estantes");

            migrationBuilder.DropTable(
                name: "tipoActivos");

            migrationBuilder.DropTable(
                name: "bodegas");
        }
    }
}
