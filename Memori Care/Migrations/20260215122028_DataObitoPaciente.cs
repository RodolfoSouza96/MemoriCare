using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memori_Care.Migrations
{
    /// <inheritdoc />
    public partial class DataObitoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataObito",
                table: "Pacientes",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataObito",
                table: "Pacientes");
        }
    }
}
