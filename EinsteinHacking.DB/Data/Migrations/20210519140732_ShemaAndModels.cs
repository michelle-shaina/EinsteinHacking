using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EinsteinHacking.Data.Migrations
{
    public partial class ShemaAndModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mod");

            migrationBuilder.CreateTable(
                name: "Challenges",
                schema: "mod",
                columns: table => new
                {
                    ChallengeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PointsOnCompletion = table.Column<int>(nullable: false),
                    PointsRemovedPerHintUsed = table.Column<int>(nullable: false),
                    LinkToexplanationVideo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.ChallengeID);
                });

            migrationBuilder.CreateTable(
                name: "UserInformation",
                schema: "mod",
                columns: table => new
                {
                    UserInformationKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.UserInformationKey);
                    table.ForeignKey(
                        name: "FK_UserInformation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hint",
                schema: "mod",
                columns: table => new
                {
                    HintID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ChallengeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hint", x => x.HintID);
                    table.ForeignKey(
                        name: "FK_Hint_Challenges_ChallengeID",
                        column: x => x.ChallengeID,
                        principalSchema: "mod",
                        principalTable: "Challenges",
                        principalColumn: "ChallengeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProgress",
                columns: table => new
                {
                    UserProgressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    ChallengeID = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    HintsUsed = table.Column<int>(nullable: false),
                    UserInformationKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgress", x => x.UserProgressID);
                    table.ForeignKey(
                        name: "FK_UserProgress_Challenges_ChallengeID",
                        column: x => x.ChallengeID,
                        principalSchema: "mod",
                        principalTable: "Challenges",
                        principalColumn: "ChallengeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProgress_UserInformation_UserInformationKey",
                        column: x => x.UserInformationKey,
                        principalSchema: "mod",
                        principalTable: "UserInformation",
                        principalColumn: "UserInformationKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_ChallengeID",
                table: "UserProgress",
                column: "ChallengeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_UserInformationKey",
                table: "UserProgress",
                column: "UserInformationKey");

            migrationBuilder.CreateIndex(
                name: "IX_Hint_ChallengeID",
                schema: "mod",
                table: "Hint",
                column: "ChallengeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_UserId",
                schema: "mod",
                table: "UserInformation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgress");

            migrationBuilder.DropTable(
                name: "Hint",
                schema: "mod");

            migrationBuilder.DropTable(
                name: "UserInformation",
                schema: "mod");

            migrationBuilder.DropTable(
                name: "Challenges",
                schema: "mod");
        }
    }
}
