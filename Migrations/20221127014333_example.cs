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
                name: "Planes",
                columns: table => new
                {
                    PkPlanes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dias = table.Column<int>(type: "int", nullable: false),
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
                    Descrpcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programadores", x => x.PkPrgramadores);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Tecnologias",
                columns: table => new
                {
                    PkTecnologias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLFoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologias", x => x.PkTecnologias);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    PkProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLMaster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FkProgramadores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.PkProyecto);
                    table.ForeignKey(
                        name: "FK_Proyectos_Programadores_FkProgramadores",
                        column: x => x.FkProgramadores,
                        principalTable: "Programadores",
                        principalColumn: "PkPrgramadores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkRoles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRoles",
                        column: x => x.FkRoles,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lista_PL",
                columns: table => new
                {
                    pkLista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Porcentaje = table.Column<int>(type: "int", nullable: false),
                    FkTecnologiass = table.Column<int>(type: "int", nullable: false),
                    FkProgramadores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista_PL", x => x.pkLista);
                    table.ForeignKey(
                        name: "FK_Lista_PL_Programadores_FkProgramadores",
                        column: x => x.FkProgramadores,
                        principalTable: "Programadores",
                        principalColumn: "PkPrgramadores",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lista_PL_Tecnologias_FkTecnologiass",
                        column: x => x.FkTecnologiass,
                        principalTable: "Tecnologias",
                        principalColumn: "PkTecnologias",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    PkMembresias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkPlanes = table.Column<int>(type: "int", nullable: false),
                    FkClientes = table.Column<int>(type: "int", nullable: false),
                    FkProyecto = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Membresias_Planes_FkPlanes",
                        column: x => x.FkPlanes,
                        principalTable: "Planes",
                        principalColumn: "PkPlanes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membresias_Proyectos_FkProyecto",
                        column: x => x.FkProyecto,
                        principalTable: "Proyectos",
                        principalColumn: "PkProyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    PkRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkUsuarios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.PkRegistro);
                    table.ForeignKey(
                        name: "FK_Registros_Usuarios_FkUsuarios",
                        column: x => x.FkUsuarios,
                        principalTable: "Usuarios",
                        principalColumn: "PkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lista_PL_FkProgramadores",
                table: "Lista_PL",
                column: "FkProgramadores");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_PL_FkTecnologiass",
                table: "Lista_PL",
                column: "FkTecnologiass");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_FkClientes",
                table: "Membresias",
                column: "FkClientes");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_FkPlanes",
                table: "Membresias",
                column: "FkPlanes");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_FkProyecto",
                table: "Membresias",
                column: "FkProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_FkProgramadores",
                table: "Proyectos",
                column: "FkProgramadores");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_FkUsuarios",
                table: "Registros",
                column: "FkUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRoles",
                table: "Usuarios",
                column: "FkRoles");
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
                name: "Tecnologias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Programadores");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
