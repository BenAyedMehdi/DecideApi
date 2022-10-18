using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecideApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFinishedAndTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsTotal",
                table: "Decisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Decisions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProsTotal",
                table: "Decisions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsTotal",
                table: "Decisions");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Decisions");

            migrationBuilder.DropColumn(
                name: "ProsTotal",
                table: "Decisions");
        }
    }
}
