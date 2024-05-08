using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class TestAddNumOfVehToMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipVehicleId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipMemberId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" },
                principalTable: "Ownerships",
                principalColumns: new[] { "MemberId", "VehicleId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipVehicleId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipMemberId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" },
                principalTable: "Ownerships",
                principalColumns: new[] { "MemberId", "VehicleId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
