using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolType",
                table: "School");

            migrationBuilder.AddColumn<int>(
                name: "SchoolTypeId",
                table: "School",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_School_SchoolTypeId",
                table: "School",
                column: "SchoolTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_SchoolType_SchoolTypeId",
                table: "School",
                column: "SchoolTypeId",
                principalTable: "SchoolType",
                principalColumn: "SchoolTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_SchoolType_SchoolTypeId",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_SchoolTypeId",
                table: "School");

            migrationBuilder.DropColumn(
                name: "SchoolTypeId",
                table: "School");

            migrationBuilder.AddColumn<string>(
                name: "SchoolType",
                table: "School",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }
    }
}
