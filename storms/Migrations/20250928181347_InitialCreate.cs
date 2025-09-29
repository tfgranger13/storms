using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storms.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storm",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Basin = table.Column<string>(type: "TEXT", nullable: false),
                    CycloneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Longitude = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<string>(type: "TEXT", nullable: false),
                    IsLandfall = table.Column<bool>(type: "INTEGER", nullable: false),
                    LandfallDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaxWindSpeed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storm", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storm");
        }
    }
}
