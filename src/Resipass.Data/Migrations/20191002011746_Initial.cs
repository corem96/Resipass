using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resipass.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVencimiento",
                table: "RegistroPagos",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 1, 1, 17, 46, 243, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 31, 3, 13, 8, 697, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "RegistroPagos",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 2, 1, 17, 46, 242, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 1, 3, 13, 8, 696, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVencimiento",
                table: "RegistroPagos",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 31, 3, 13, 8, 697, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 1, 1, 17, 46, 243, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "RegistroPagos",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 1, 3, 13, 8, 696, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 2, 1, 17, 46, 242, DateTimeKind.Utc));
        }
    }
}
