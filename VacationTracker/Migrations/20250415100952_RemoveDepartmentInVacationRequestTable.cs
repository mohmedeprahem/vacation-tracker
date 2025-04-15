using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDepartmentInVacationRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacationRequest_Department_DepartmentId",
                table: "VacationRequest");

            migrationBuilder.DropIndex(
                name: "IX_VacationRequest_DepartmentId",
                table: "VacationRequest");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "VacationRequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "VacationRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequest_DepartmentId",
                table: "VacationRequest",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationRequest_Department_DepartmentId",
                table: "VacationRequest",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
