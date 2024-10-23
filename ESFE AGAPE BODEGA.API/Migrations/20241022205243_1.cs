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
                name: "correlativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    AliasInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliasFinal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_correlativos", x => x.Id);
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
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventarioActivos_estantes_EstanteId",
                        column: x => x.EstanteId,
                        principalTable: "estantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "detalleSolicitudActivos",
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
                    table.PrimaryKey("PK_detalleSolicitudActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleSolicitudActivos_activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleSolicitudActivos_paqueteActivos_PaqueteActivoId",
                        column: x => x.PaqueteActivoId,
                        principalTable: "paqueteActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleSolicitudActivos_solicitudActivos_SolicitudActivoId",
                        column: x => x.SolicitudActivoId,
                        principalTable: "solicitudActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InventarioActivoId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id");
                });

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
                name: "IX_detalleSolicitudActivos_ActivoId",
                table: "detalleSolicitudActivos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleSolicitudActivos_PaqueteActivoId",
                table: "detalleSolicitudActivos",
                column: "PaqueteActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleSolicitudActivos_SolicitudActivoId",
                table: "detalleSolicitudActivos",
                column: "SolicitudActivoId");

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
                name: "IX_kardexActivos_InventarioActivoId",
                table: "kardexActivos",
                column: "InventarioActivoId");

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
                name: "correlativos");

            migrationBuilder.DropTable(
                name: "detalleIngresos");

            migrationBuilder.DropTable(
                name: "detallePaqueteActivos");

            migrationBuilder.DropTable(
                name: "detalleSolicitudActivos");

            migrationBuilder.DropTable(
                name: "kardexActivos");

            migrationBuilder.DropTable(
                name: "ajusteInventarios");

            migrationBuilder.DropTable(
                name: "ingresoactivos");

            migrationBuilder.DropTable(
                name: "paqueteActivos");

            migrationBuilder.DropTable(
                name: "solicitudActivos");

            migrationBuilder.DropTable(
                name: "inventarioActivos");

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
