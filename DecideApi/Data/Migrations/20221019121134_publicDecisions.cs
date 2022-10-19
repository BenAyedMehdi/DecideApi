using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecideApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class publicDecisions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPulic",
                table: "Decisions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPulic",
                table: "Decisions");
        }
    }
}
