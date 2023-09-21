using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UtilityAccountNumber",
                table: "Meter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UtilityAccountNumber",
                table: "Meter");
        }
    }
}
