using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Meter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SchoolLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meter_SchoolId",
                table: "Meter",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_School_SchoolId",
                table: "Meter",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meter_School_SchoolId",
                table: "Meter");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropIndex(
                name: "IX_Meter_SchoolId",
                table: "Meter");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Meter");
        }
    }
}
