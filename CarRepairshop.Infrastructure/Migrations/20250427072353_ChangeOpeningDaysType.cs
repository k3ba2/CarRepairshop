using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRepairshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOpeningDaysType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OpeningDays",
                table: "CarRepairshopOpeningHours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpeningDays",
                table: "CarRepairshopOpeningHours",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
