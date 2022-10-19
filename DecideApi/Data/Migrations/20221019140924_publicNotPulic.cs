using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecideApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class publicNotPulic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPulic",
                table: "Decisions",
                newName: "IsPublic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Decisions",
                newName: "IsPulic");
        }
    }
}
