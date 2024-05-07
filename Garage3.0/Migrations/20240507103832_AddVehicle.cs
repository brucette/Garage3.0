using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Parkings");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Parkings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipVehicleId",
                table: "Parkings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipMemberId",
                table: "Parkings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_VehicleId",
                table: "Parkings",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Parkings",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" },
                principalTable: "Ownerships",
                principalColumns: new[] { "MemberId", "VehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Vehicle_VehicleId",
                table: "Parkings",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Vehicle_VehicleId",
                table: "Parkings");

            migrationBuilder.DropIndex(
                name: "IX_Parkings_VehicleId",
                table: "Parkings");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Parkings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipVehicleId",
                table: "Parkings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipMemberId",
                table: "Parkings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Parkings",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" },
                principalTable: "Ownerships",
                principalColumns: new[] { "MemberId", "VehicleId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
