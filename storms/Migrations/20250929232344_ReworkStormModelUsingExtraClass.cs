using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storms.Migrations
{
    /// <inheritdoc />
    public partial class ReworkStormModelUsingExtraClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LandfallDates",
                table: "Storm",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Storm",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LandfallDates",
                table: "Storm",
                type: "NVARCHAR(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
