using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camping.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoPrestamos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Loans",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Loans",
                newName: "Notes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
