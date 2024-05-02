using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class fixedKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Member_MemberId",
                table: "Ownership");

            migrationBuilder.DropIndex(
                name: "IX_Ownership_MemberId",
                table: "Ownership");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Ownership");

            migrationBuilder.DropColumn(
                name: "PersonNumberEntity",
                table: "Ownership");

            migrationBuilder.RenameColumn(
                name: "RegisterNumberEntity",
                table: "Ownership",
                newName: "PersonNumber");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Member",
                newName: "PersonNumber");

            migrationBuilder.AddColumn<string>(
                name: "MemberPersonNumber",
                table: "Ownership",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ownership_MemberPersonNumber",
                table: "Ownership",
                column: "MemberPersonNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Ownership_Member_MemberPersonNumber",
                table: "Ownership",
                column: "MemberPersonNumber",
                principalTable: "Member",
                principalColumn: "PersonNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Member_MemberPersonNumber",
                table: "Ownership");

            migrationBuilder.DropIndex(
                name: "IX_Ownership_MemberPersonNumber",
                table: "Ownership");

            migrationBuilder.DropColumn(
                name: "MemberPersonNumber",
                table: "Ownership");

            migrationBuilder.RenameColumn(
                name: "PersonNumber",
                table: "Ownership",
                newName: "RegisterNumberEntity");

            migrationBuilder.RenameColumn(
                name: "PersonNumber",
                table: "Member",
                newName: "MemberId");

            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Ownership",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonNumberEntity",
                table: "Ownership",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ownership_MemberId",
                table: "Ownership",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ownership_Member_MemberId",
                table: "Ownership",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
