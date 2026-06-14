using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorVehicleOperationalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                UPDATE vehicles 
                SET status = CASE 
                    WHEN status = 'Withdrawn' THEN 'Withdrawn' 
                    ELSE 'Active' 
                END;
                """);

            migrationBuilder.RenameColumn(
                name: "status",
                table: "vehicles",
                newName: "operational_status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                UPDATE vehicles
                SET operational_status = CASE
                    WHEN operational_status = 'Withdrawn' THEN 'Withdrawn'
                    ELSE 'Available'
                END;
                """);

            migrationBuilder.RenameColumn(
                name: "operational_status",
                table: "vehicles",
                newName: "status");
        }
    }
}
