using Microsoft.EntityFrameworkCore.Migrations;

namespace EinsteinHacking.Data.Migrations
{
    public partial class ShemaAndModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserProgress",
                newName: "UserProgress",
                newSchema: "mod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserProgress",
                schema: "mod",
                newName: "UserProgress");
        }
    }
}
