using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class AddedMembersController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Ownership");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Ownership",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
