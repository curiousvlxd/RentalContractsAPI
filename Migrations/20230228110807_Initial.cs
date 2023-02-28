using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalContractsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentPlacementContract",
                columns: table => new
                {
                    ContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionPremisesCode = table.Column<int>(type: "int", nullable: false),
                    TechnologyEquipmentTypeCode = table.Column<int>(type: "int", nullable: false),
                    NumOfUnits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipmen__C90D340964F19D7A", x => x.ContractID);
                });

            migrationBuilder.CreateTable(
                name: "ProductionPremises",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Ukrainian_CP1251_CI_AS"),
                    RegulatoryArea = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producti__A25C5AA6013D0B85", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyEquipmentType",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Ukrainian_CP1251_CI_AS"),
                    Area = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Technolo__A25C5AA641CFED7E", x => x.Code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPlacementContract");

            migrationBuilder.DropTable(
                name: "ProductionPremises");

            migrationBuilder.DropTable(
                name: "TechnologyEquipmentType");
        }
    }
}
