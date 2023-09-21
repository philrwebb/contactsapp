using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contactsapp.Migrations
{
    public partial class metermig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolType",
                columns: table => new
                {
                    SchoolTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TypeLongDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolType", x => x.SchoolTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolType");
        }
    }
}
