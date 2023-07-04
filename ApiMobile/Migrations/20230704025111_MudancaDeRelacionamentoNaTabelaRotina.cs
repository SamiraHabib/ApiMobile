using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class MudancaDeRelacionamentoNaTabelaRotina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rotinaDiaSemana_dia_semana_DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_rotinaDiaSemana_dia_semana_IdDiaSemana",
                table: "rotinaDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_rotinaDiaSemana_rotina_IdRotina",
                table: "rotinaDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_rotinaDiaSemana_rotina_RotinaIdRotina",
                table: "rotinaDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_rotinaExercicio_exercicio_IdExercicio",
                table: "rotinaExercicio");

            migrationBuilder.DropForeignKey(
                name: "FK_rotinaExercicio_rotina_IdRotina",
                table: "rotinaExercicio");

            migrationBuilder.DropIndex(
                name: "IX_rotinaExercicio_IdExercicio",
                table: "rotinaExercicio");

            migrationBuilder.DropIndex(
                name: "IX_rotinaDiaSemana_DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana");

            migrationBuilder.DropIndex(
                name: "IX_rotinaDiaSemana_RotinaIdRotina",
                table: "rotinaDiaSemana");

            migrationBuilder.DropColumn(
                name: "DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana");

            migrationBuilder.DropColumn(
                name: "RotinaIdRotina",
                table: "rotinaDiaSemana");

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaDiaSemana_dia_semana_IdDiaSemana",
                table: "rotinaDiaSemana",
                column: "IdDiaSemana",
                principalTable: "dia_semana",
                principalColumn: "IdDiaSemana",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaDiaSemana_rotina_IdRotina",
                table: "rotinaDiaSemana",
                column: "IdRotina",
                principalTable: "rotina",
                principalColumn: "IdRotina",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rotinaDiaSemana_dia_semana_IdDiaSemana",
                table: "rotinaDiaSemana");

            migrationBuilder.DropForeignKey(
                name: "FK_rotinaDiaSemana_rotina_IdRotina",
                table: "rotinaDiaSemana");

            migrationBuilder.AddColumn<int>(
                name: "DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RotinaIdRotina",
                table: "rotinaDiaSemana",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rotinaExercicio_IdExercicio",
                table: "rotinaExercicio",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaDiaSemana_DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana",
                column: "DiaSemanaIdDiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaDiaSemana_RotinaIdRotina",
                table: "rotinaDiaSemana",
                column: "RotinaIdRotina");

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaDiaSemana_dia_semana_DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana",
                column: "DiaSemanaIdDiaSemana",
                principalTable: "dia_semana",
                principalColumn: "IdDiaSemana");

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaDiaSemana_dia_semana_IdDiaSemana",
                table: "rotinaDiaSemana",
                column: "IdDiaSemana",
                principalTable: "dia_semana",
                principalColumn: "IdDiaSemana",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaDiaSemana_rotina_IdRotina",
                table: "rotinaDiaSemana",
                column: "IdRotina",
                principalTable: "rotina",
                principalColumn: "IdRotina",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaDiaSemana_rotina_RotinaIdRotina",
                table: "rotinaDiaSemana",
                column: "RotinaIdRotina",
                principalTable: "rotina",
                principalColumn: "IdRotina");

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaExercicio_exercicio_IdExercicio",
                table: "rotinaExercicio",
                column: "IdExercicio",
                principalTable: "exercicio",
                principalColumn: "IdExercicio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rotinaExercicio_rotina_IdRotina",
                table: "rotinaExercicio",
                column: "IdRotina",
                principalTable: "rotina",
                principalColumn: "IdRotina",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
