using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeShortDescription",
                table: "MeterType",
                newName: "typeShortDescription");

            migrationBuilder.RenameColumn(
                name: "TypeLongDescription",
                table: "MeterType",
                newName: "typeLongDescription");

            migrationBuilder.RenameColumn(
                name: "MeterTypeId",
                table: "MeterType",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "typeShortDescription",
                table: "MeterType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "typeLongDescription",
                table: "MeterType",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MeterType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MeterType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "MeterType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "MeterType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "MeterType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "effFrom",
                table: "MeterType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "effTo",
                table: "MeterType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "typeCode",
                table: "MeterType",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "active",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "effFrom",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "effTo",
                table: "MeterType");

            migrationBuilder.DropColumn(
                name: "typeCode",
                table: "MeterType");

            migrationBuilder.RenameColumn(
                name: "typeShortDescription",
                table: "MeterType",
                newName: "TypeShortDescription");

            migrationBuilder.RenameColumn(
                name: "typeLongDescription",
                table: "MeterType",
                newName: "TypeLongDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MeterType",
                newName: "MeterTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "TypeShortDescription",
                table: "MeterType",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeLongDescription",
                table: "MeterType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
