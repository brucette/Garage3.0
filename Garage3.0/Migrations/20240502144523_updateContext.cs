using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class updateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Member_MemberPersonNumber",
                table: "Ownership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ownership",
                table: "Ownership");

            migrationBuilder.DropIndex(
                name: "IX_Ownership_MemberPersonNumber",
                table: "Ownership");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ownership");

            migrationBuilder.DropColumn(
                name: "MemberPersonNumber",
                table: "Ownership");

            migrationBuilder.DropColumn(
                name: "RegisterNumber",
                table: "Ownership");

            migrationBuilder.AlterColumn<string>(
                name: "PersonNumber",
                table: "Ownership",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ownership",
                table: "Ownership",
                columns: new[] { "PersonNumber", "VehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ownership_Member_PersonNumber",
                table: "Ownership",
                column: "PersonNumber",
                principalTable: "Member",
                principalColumn: "PersonNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Member_PersonNumber",
                table: "Ownership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ownership",
                table: "Ownership");

            migrationBuilder.AlterColumn<string>(
                name: "PersonNumber",
                table: "Ownership",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ownership",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "MemberPersonNumber",
                table: "Ownership",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisterNumber",
                table: "Ownership",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ownership",
                table: "Ownership",
                column: "Id");

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
    }
}
