using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDeDeleteParaRotinaENotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rotina_paciente_IdPaciente",
                table: "rotina");

            migrationBuilder.UpdateData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 7,
                column: "Nome",
                value: "S�bado");

            migrationBuilder.AddForeignKey(
                name: "FK_rotina_paciente_IdPaciente",
                table: "rotina",
                column: "IdPaciente",
                principalTable: "paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rotina_paciente_IdPaciente",
                table: "rotina");

            migrationBuilder.UpdateData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 7,
                column: "Nome",
                value: "Sábado");

            migrationBuilder.AddForeignKey(
                name: "FK_rotina_paciente_IdPaciente",
                table: "rotina",
                column: "IdPaciente",
                principalTable: "paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
