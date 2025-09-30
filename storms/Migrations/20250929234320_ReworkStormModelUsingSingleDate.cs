using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storms.Migrations
{
    /// <inheritdoc />
    public partial class ReworkStormModelUsingSingleDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LandfallDates",
                table: "Storm",
                newName: "LandfallDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LandfallDate",
                table: "Storm",
                newName: "LandfallDates");
        }
    }
}
