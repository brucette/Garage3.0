using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntitiesAndDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Member_PersonNumber",
                table: "Ownership");

            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Receipt_ReceiptId",
                table: "Ownership");

            migrationBuilder.DropForeignKey(
                name: "FK_Ownership_Vehicle_VehicleId",
                table: "Ownership");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleType_Vehicle_VehicleId",
                table: "VehicleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ownership",
                table: "Ownership");

            migrationBuilder.DropIndex(
                name: "IX_Ownership_ReceiptId",
                table: "Ownership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CheckoutTime",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "TotalParkingTime",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Ownership");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "Ownership",
                newName: "Ownerships");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameColumn(
                name: "PersonNumber",
                table: "Ownerships",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Ownership_VehicleId",
                table: "Ownerships",
                newName: "IX_Ownerships_VehicleId");

            migrationBuilder.RenameColumn(
                name: "PersonNumber",
                table: "Members",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "VehicleType",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Receipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OwnershipMemberId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnershipVehicleId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotParkingTime",
                table: "Receipts",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "VehicleId",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Ownerships",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ownerships",
                table: "Ownerships",
                columns: new[] { "MemberId", "VehicleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotNumber = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    OwnershipMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnershipVehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkings_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                        columns: x => new { x.OwnershipMemberId, x.OwnershipVehicleId },
                        principalTable: "Ownerships",
                        principalColumns: new[] { "MemberId", "VehicleId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_OwnershipMemberId_OwnershipVehicleId",
                table: "Parkings",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ownerships_Members_MemberId",
                table: "Ownerships",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ownerships_Vehicles_VehicleId",
                table: "Ownerships",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts",
                columns: new[] { "OwnershipMemberId", "OwnershipVehicleId" },
                principalTable: "Ownerships",
                principalColumns: new[] { "MemberId", "VehicleId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleType_Vehicles_VehicleId",
                table: "VehicleType",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownerships_Members_MemberId",
                table: "Ownerships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ownerships_Vehicles_VehicleId",
                table: "Ownerships");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Ownerships_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleType_Vehicles_VehicleId",
                table: "VehicleType");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_OwnershipMemberId_OwnershipVehicleId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ownerships",
                table: "Ownerships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "OwnershipMemberId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "OwnershipVehicleId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "TotParkingTime",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Receipts");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "Ownerships",
                newName: "Ownership");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Ownership",
                newName: "PersonNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Ownerships_VehicleId",
                table: "Ownership",
                newName: "IX_Ownership_VehicleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Member",
                newName: "PersonNumber");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "VehicleType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Vehicle",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutTime",
                table: "Receipt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalParkingTime",
                table: "Receipt",
                type: "time",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Ownership",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Ownership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ownership",
                table: "Ownership",
                columns: new[] { "PersonNumber", "VehicleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "PersonNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Ownership_ReceiptId",
                table: "Ownership",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ownership_Member_PersonNumber",
                table: "Ownership",
                column: "PersonNumber",
                principalTable: "Member",
                principalColumn: "PersonNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ownership_Receipt_ReceiptId",
                table: "Ownership",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ownership_Vehicle_VehicleId",
                table: "Ownership",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleType_Vehicle_VehicleId",
                table: "VehicleType",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
