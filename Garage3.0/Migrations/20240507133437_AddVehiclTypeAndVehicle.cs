using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class AddVehiclTypeAndVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Parkings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_VehicleId",
                table: "Parkings",
                column: "VehicleId");

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
        }
    }
}
