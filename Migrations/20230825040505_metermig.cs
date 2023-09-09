using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "MeterType",
                columns: table => new
                {
                    MeterTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TypeLongDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeUnitOfMeasure = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterType", x => x.MeterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Meter",
                columns: table => new
                {
                    MeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MeterDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MeterTypeId = table.Column<int>(type: "int", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter", x => x.MeterId);
                    table.ForeignKey(
                        name: "FK_Meter_MeterType_MeterTypeId",
                        column: x => x.MeterTypeId,
                        principalTable: "MeterType",
                        principalColumn: "MeterTypeId");
                });

            migrationBuilder.CreateTable(
                name: "MeterReading",
                columns: table => new
                {
                    MeterReadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadingValue = table.Column<double>(type: "float", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReading", x => x.MeterReadingId);
                    table.ForeignKey(
                        name: "FK_MeterReading_Meter_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meter",
                        principalColumn: "MeterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meter_MeterTypeId",
                table: "Meter",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReading_MeterId",
                table: "MeterReading",
                column: "MeterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "MeterReading");

            migrationBuilder.DropTable(
                name: "Meter");

            migrationBuilder.DropTable(
                name: "MeterType");
        }
    }
}
