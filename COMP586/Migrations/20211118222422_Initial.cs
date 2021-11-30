using Microsoft.EntityFrameworkCore.Migrations;

namespace COMP586.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ownerID = table.Column<int>(type: "int", nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DOB = table.Column<int>(type: "int", nullable: false),
                    LicenseNum = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    LicenseStatus = table.Column<int>(type: "int", nullable: false),
                    stateResidence = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ownerID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleInfo",
                columns: table => new
                {
                    vehicleID = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    modelYear = table.Column<int>(type: "int", nullable: false),
                    make = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    model = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    color = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    mileage = table.Column<int>(type: "int", nullable: true),
                    ownerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInfo", x => x.vehicleID);
                    table.ForeignKey(
                        name: "FK_VehicleInfo_Owner",
                        column: x => x.ownerID,
                        principalTable: "Owner",
                        principalColumn: "ownerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfo_ownerID",
                table: "VehicleInfo",
                column: "ownerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleInfo");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
