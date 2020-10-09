using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class andemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 9, 0, 17, 56, 868, DateTimeKind.Local).AddTicks(4036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 9, 0, 7, 42, 994, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 9, 0, 17, 56, 878, DateTimeKind.Local).AddTicks(891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 9, 0, 7, 43, 5, DateTimeKind.Local).AddTicks(7823));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 9, 0, 7, 42, 994, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 9, 0, 17, 56, 868, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 9, 0, 7, 43, 5, DateTimeKind.Local).AddTicks(7823),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 9, 0, 17, 56, 878, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
