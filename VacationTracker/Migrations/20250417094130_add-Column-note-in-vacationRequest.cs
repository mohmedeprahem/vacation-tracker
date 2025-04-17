using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationTracker.Migrations
{
    /// <inheritdoc />
    public partial class addColumnnoteinvacationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "VacationRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "VacationRequests");
        }
    }
}
