using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EinsteinHacking.Data.Migrations
{
    public partial class SolutionOnChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Solution",
                schema: "mod",
                table: "Challenges",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 424, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 13, 18, 51, 22, 430, DateTimeKind.Local).AddTicks(1580));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solution",
                schema: "mod",
                table: "Challenges");

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 106, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(990));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                schema: "mod",
                table: "Challenges",
                keyColumn: "ChallengeID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 6, 17, 6, 37, 112, DateTimeKind.Local).AddTicks(1050));
        }
    }
}
