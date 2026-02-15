using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memori_Care.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoNumeroConselho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroConselho",
                table: "Profissionais",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroConselho",
                table: "Profissionais");
        }
    }
}
