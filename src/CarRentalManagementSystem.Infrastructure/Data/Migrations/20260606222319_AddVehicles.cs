using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vin = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    registration_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    production_year = table.Column<int>(type: "integer", nullable: false),
                    vehicle_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_mileage = table.Column<int>(type: "integer", nullable: false),
                    fuel_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    transmission_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    next_technical_inspection_date = table.Column<DateOnly>(type: "date", nullable: false),
                    next_service_mileage = table.Column<int>(type: "integer", nullable: false),
                    next_service_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicles_branches_current_branch_id",
                        column: x => x.current_branch_id,
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehicles_vehicle_categories_vehicle_category_id",
                        column: x => x.vehicle_category_id,
                        principalTable: "vehicle_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_current_branch_id",
                table: "vehicles",
                column: "current_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_registration_number",
                table: "vehicles",
                column: "registration_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_vehicle_category_id",
                table: "vehicles",
                column: "vehicle_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_vin",
                table: "vehicles",
                column: "vin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles");
        }
    }
}
