using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storms.Migrations
{
    /// <inheritdoc />
    public partial class ReworkStormModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basin",
                table: "Storm");

            migrationBuilder.DropColumn(
                name: "CycloneNumber",
                table: "Storm");

            migrationBuilder.DropColumn(
                name: "IsLandfall",
                table: "Storm");

            migrationBuilder.DropColumn(
                name: "LandfallDateTime",
                table: "Storm");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Storm");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Storm");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Storm");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Storm",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "LandfallDates",
                table: "Storm",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandfallDates",
                table: "Storm");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Basin",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CycloneNumber",
                table: "Storm",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLandfall",
                table: "Storm",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LandfallDateTime",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Storm",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
