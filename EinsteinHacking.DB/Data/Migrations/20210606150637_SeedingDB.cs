using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EinsteinHacking.Data.Migrations
{
    public partial class SeedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "mod",
                table: "Challenges",
                columns: new[] { "ChallengeID", "CreatedAt", "Deleted", "DeletedAt", "Description", "LinkToexplanationVideo", "Name", "PointsOnCompletion", "PointsRemovedPerHintUsed" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 6, 17, 6, 37, 106, DateTimeKind.Local).AddTicks(8790), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic combination safety (The password is a combination of 4 numbers)", null, "Challenge 1", 3, 0 },
                    { 2, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(990), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic password safety", null, "Challenge 2", 4, 1 },
                    { 3, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1030), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic Website Safety", null, "Challenge 3", 8, 2 },
                    { 4, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1030), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cookies", null, "Challenge 4", 10, 3 },
                    { 5, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Try every combination there is (The password is a combination of 8 lowercase letter in the english alphabet)", null, "Challenge 5", 15, 4 },
                    { 6, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Social Engineering", null, "Challenge 6", 20, 5 },
                    { 7, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL ", null, "Challenge 7", 25, 6 },
                    { 8, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Encryption", null, "Challenge 8", 20, 5 },
                    { 9, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1050), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steganografie", null, "Challenge 9", 25, 16 },
                    { 10, new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1050), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Certificate fun", null, "Challenge 10", 30, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 10);
        }
    }
}
