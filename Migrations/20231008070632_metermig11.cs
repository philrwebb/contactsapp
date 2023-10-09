using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeterReadingId",
                table: "MeterReading",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MeterReading",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MeterReading",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "MeterReading",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "MeterReading",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "MeterReading",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MeterReading");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MeterReading");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "MeterReading");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "MeterReading");

            migrationBuilder.DropColumn(
                name: "active",
                table: "MeterReading");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MeterReading",
                newName: "MeterReadingId");
        }
    }
}
