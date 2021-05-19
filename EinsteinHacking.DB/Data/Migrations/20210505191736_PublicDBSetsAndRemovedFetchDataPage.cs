using Microsoft.EntityFrameworkCore.Migrations;

namespace EinsteinHacking.Data.Migrations
{
    public partial class PublicDBSetsAndRemovedFetchDataPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProgresses_Challenges_ChallengeID",
                table: "userProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_userProgresses_UserInformation_UserInformationKey",
                table: "userProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userProgresses",
                table: "userProgresses");

            migrationBuilder.RenameTable(
                name: "userProgresses",
                newName: "UserProgresses");

            migrationBuilder.RenameIndex(
                name: "IX_userProgresses_UserInformationKey",
                table: "UserProgresses",
                newName: "IX_UserProgresses_UserInformationKey");

            migrationBuilder.RenameIndex(
                name: "IX_userProgresses_ChallengeID",
                table: "UserProgresses",
                newName: "IX_UserProgresses_ChallengeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProgresses",
                table: "UserProgresses",
                column: "UserProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgresses_Challenges_ChallengeID",
                table: "UserProgresses",
                column: "ChallengeID",
                principalTable: "Challenges",
                principalColumn: "ChallengeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgresses_UserInformation_UserInformationKey",
                table: "UserProgresses",
                column: "UserInformationKey",
                principalTable: "UserInformation",
                principalColumn: "UserInformationKey",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProgresses_Challenges_ChallengeID",
                table: "UserProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgresses_UserInformation_UserInformationKey",
                table: "UserProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProgresses",
                table: "UserProgresses");

            migrationBuilder.RenameTable(
                name: "UserProgresses",
                newName: "userProgresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserProgresses_UserInformationKey",
                table: "userProgresses",
                newName: "IX_userProgresses_UserInformationKey");

            migrationBuilder.RenameIndex(
                name: "IX_UserProgresses_ChallengeID",
                table: "userProgresses",
                newName: "IX_userProgresses_ChallengeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userProgresses",
                table: "userProgresses",
                column: "UserProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_userProgresses_Challenges_ChallengeID",
                table: "userProgresses",
                column: "ChallengeID",
                principalTable: "Challenges",
                principalColumn: "ChallengeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userProgresses_UserInformation_UserInformationKey",
                table: "userProgresses",
                column: "UserInformationKey",
                principalTable: "UserInformation",
                principalColumn: "UserInformationKey",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
