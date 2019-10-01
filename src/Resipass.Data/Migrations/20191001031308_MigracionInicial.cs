using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resipass.Data.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "domicilio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(maxLength: 250, nullable: false),
                    Numero = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domicilio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 70, nullable: false),
                    Apellido = table.Column<string>(maxLength: 70, nullable: false),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "residente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 80, nullable: false),
                    Apellido = table.Column<string>(maxLength: 80, nullable: false),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    DomicilioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_residente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_residente_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aviso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comunicado = table.Column<string>(maxLength: 250, nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aviso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aviso_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Vigencia = table.Column<DateTime>(nullable: false),
                    Activa = table.Column<bool>(nullable: false, defaultValue: true),
                    ResidenteId = table.Column<int>(nullable: false),
                    DomicilioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarjeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tarjeta_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tarjeta_residente_ResidenteId",
                        column: x => x.ResidenteId,
                        principalTable: "residente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPagos",
                columns: table => new
                {
                    ResidenteId = table.Column<int>(nullable: false),
                    TarjetaId = table.Column<int>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 10, 1, 3, 13, 8, 696, DateTimeKind.Utc)),
                    FechaVencimiento = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 10, 31, 3, 13, 8, 697, DateTimeKind.Utc)),
                    Importe = table.Column<decimal>(nullable: false, defaultValue: 300m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPagos", x => new { x.ResidenteId, x.TarjetaId });
                    table.ForeignKey(
                        name: "FK_RegistroPagos_residente_ResidenteId",
                        column: x => x.ResidenteId,
                        principalTable: "residente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroPagos_tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "tarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aviso_UsuarioId",
                table: "aviso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPagos_TarjetaId",
                table: "RegistroPagos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_residente_DomicilioId",
                table: "residente",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_tarjeta_DomicilioId",
                table: "tarjeta",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_tarjeta_ResidenteId",
                table: "tarjeta",
                column: "ResidenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aviso");

            migrationBuilder.DropTable(
                name: "RegistroPagos");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "tarjeta");

            migrationBuilder.DropTable(
                name: "residente");

            migrationBuilder.DropTable(
                name: "domicilio");
        }
    }
}
