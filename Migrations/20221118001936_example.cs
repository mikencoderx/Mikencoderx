using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mikencoderx.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    PkAdministradores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.PkAdministradores);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PkCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PkCliente);
                });

            migrationBuilder.CreateTable(
                name: "Lenguajes",
                columns: table => new
                {
                    PkLenguajes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcentaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenguajes", x => x.PkLenguajes);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PkPlanes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PkPlanes);
                });

            migrationBuilder.CreateTable(
                name: "Programadores",
                columns: table => new
                {
                    PkPrgramadores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrpcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programadores", x => x.PkPrgramadores);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    PkRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkAdministrador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.PkRegistro);
                    table.ForeignKey(
                        name: "FK_Registros_Administradores_FkAdministrador",
                        column: x => x.FkAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "PkAdministradores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalles",
                columns: table => new
                {
                    PkDetelle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FwechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkPlanes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles", x => x.PkDetelle);
                    table.ForeignKey(
                        name: "FK_Detalles_Planes_FkPlanes",
                        column: x => x.FkPlanes,
                        principalTable: "Planes",
                        principalColumn: "PkPlanes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lista_PL",
                columns: table => new
                {
                    pkLista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkLenguajes = table.Column<int>(type: "int", nullable: false),
                    FkProgramadores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista_PL", x => x.pkLista);
                    table.ForeignKey(
                        name: "FK_Lista_PL_Lenguajes_FkLenguajes",
                        column: x => x.FkLenguajes,
                        principalTable: "Lenguajes",
                        principalColumn: "PkLenguajes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lista_PL_Programadores_FkProgramadores",
                        column: x => x.FkProgramadores,
                        principalTable: "Programadores",
                        principalColumn: "PkPrgramadores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    PkProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URLWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLMaster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkProgramadores = table.Column<int>(type: "int", nullable: false),
                    ProgramadorPkPrgramadores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.PkProyecto);
                    table.ForeignKey(
                        name: "FK_Proyectos_Programadores_ProgramadorPkPrgramadores",
                        column: x => x.ProgramadorPkPrgramadores,
                        principalTable: "Programadores",
                        principalColumn: "PkPrgramadores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    PkMembresias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FkClientes = table.Column<int>(type: "int", nullable: false),
                    FkProyecto = table.Column<int>(type: "int", nullable: false),
                    ProyectosPkProyecto = table.Column<int>(type: "int", nullable: false),
                    FkDetalles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresias", x => x.PkMembresias);
                    table.ForeignKey(
                        name: "FK_Membresias_Clientes_FkClientes",
                        column: x => x.FkClientes,
                        principalTable: "Clientes",
                        principalColumn: "PkCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membresias_Detalles_FkDetalles",
                        column: x => x.FkDetalles,
                        principalTable: "Detalles",
                        principalColumn: "PkDetelle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membresias_Proyectos_ProyectosPkProyecto",
                        column: x => x.ProyectosPkProyecto,
                        principalTable: "Proyectos",
                        principalColumn: "PkProyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_FkPlanes",
                table: "Detalles",
                column: "FkPlanes");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_PL_FkLenguajes",
                table: "Lista_PL",
                column: "FkLenguajes");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_PL_FkProgramadores",
                table: "Lista_PL",
                column: "FkProgramadores");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_FkClientes",
                table: "Membresias",
                column: "FkClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_FkDetalles",
                table: "Membresias",
                column: "FkDetalles");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_ProyectosPkProyecto",
                table: "Membresias",
                column: "ProyectosPkProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ProgramadorPkPrgramadores",
                table: "Proyectos",
                column: "ProgramadorPkPrgramadores");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_FkAdministrador",
                table: "Registros",
                column: "FkAdministrador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lista_PL");

            migrationBuilder.DropTable(
                name: "Membresias");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Lenguajes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Detalles");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Programadores");
        }
    }
}
