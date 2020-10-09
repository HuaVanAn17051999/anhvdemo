using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 9, 0, 7, 42, 994, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 8, 23, 58, 40, 248, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 9, 0, 7, 43, 5, DateTimeKind.Local).AddTicks(7823),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 8, 23, 58, 40, 258, DateTimeKind.Local).AddTicks(1222));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 8, 23, 58, 40, 248, DateTimeKind.Local).AddTicks(3977),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 9, 0, 7, 42, 994, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 8, 23, 58, 40, 258, DateTimeKind.Local).AddTicks(1222),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 9, 0, 7, 43, 5, DateTimeKind.Local).AddTicks(7823));
        }
    }
}
