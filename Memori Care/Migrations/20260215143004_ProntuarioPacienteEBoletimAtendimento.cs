using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memori_Care.Migrations
{
    /// <inheritdoc />
    public partial class ProntuarioPacienteEBoletimAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroProntuario",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroProntuario",
                table: "Pacientes");
        }
    }
}
