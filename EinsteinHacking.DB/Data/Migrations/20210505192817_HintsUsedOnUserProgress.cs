using Microsoft.EntityFrameworkCore.Migrations;

namespace EinsteinHacking.Data.Migrations
{
    public partial class HintsUsedOnUserProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HintsUsed",
                table: "UserProgresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HintsUsed",
                table: "UserProgresses");
        }
    }
}
