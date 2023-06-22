using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class CriandoClassesDeRotinaENotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IntervaloTemp",
                table: "rotina",
                type: "varchar(8)", // Adjust the data type as per your database
                nullable: true);

            migrationBuilder.Sql("UPDATE rotina SET IntervaloTemp = CONCAT('00:', RIGHT('00' + CAST(Intervalo AS varchar), 2), ':00')");

            migrationBuilder.DropColumn(
                name: "Intervalo",
                table: "rotina");

            migrationBuilder.RenameColumn(
                name: "IntervaloTemp",
                table: "rotina",
                newName: "Intervalo");

            migrationBuilder.CreateTable(
                name: "notificacao",
                columns: table => new
                {
                    IdNotificacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRotina = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enviado = table.Column<bool>(type: "bit", nullable: false),
                    RotinaIdRotina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificacao", x => x.IdNotificacao);
                    table.ForeignKey(
                        name: "FK_notificacao_rotina_IdRotina",
                        column: x => x.IdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notificacao_rotina_RotinaIdRotina",
                        column: x => x.RotinaIdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina");
                });

            migrationBuilder.CreateTable(
                name: "rotinaDiaSemana",
                columns: table => new
                {
                    IdRotina = table.Column<int>(type: "int", nullable: false),
                    IdDiaSemana = table.Column<int>(type: "int", nullable: false),
                    DiaSemanaIdDiaSemana = table.Column<int>(type: "int", nullable: true),
                    RotinaIdRotina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rotinaDiaSemana", x => new { x.IdRotina, x.IdDiaSemana });
                    table.ForeignKey(
                        name: "FK_rotinaDiaSemana_dia_semana_DiaSemanaIdDiaSemana",
                        column: x => x.DiaSemanaIdDiaSemana,
                        principalTable: "dia_semana",
                        principalColumn: "IdDiaSemana");
                    table.ForeignKey(
                        name: "FK_rotinaDiaSemana_dia_semana_IdDiaSemana",
                        column: x => x.IdDiaSemana,
                        principalTable: "dia_semana",
                        principalColumn: "IdDiaSemana",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rotinaDiaSemana_rotina_IdRotina",
                        column: x => x.IdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rotinaDiaSemana_rotina_RotinaIdRotina",
                        column: x => x.RotinaIdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina");
                });

            migrationBuilder.CreateTable(
                name: "rotinaExercicio",
                columns: table => new
                {
                    IdRotina = table.Column<int>(type: "int", nullable: false),
                    IdExercicio = table.Column<int>(type: "int", nullable: false),
                    ExercicioIdExercicio = table.Column<int>(type: "int", nullable: true),
                    RotinaIdRotina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rotinaExercicio", x => new { x.IdRotina, x.IdExercicio });
                    table.ForeignKey(
                        name: "FK_rotinaExercicio_exercicio_ExercicioIdExercicio",
                        column: x => x.ExercicioIdExercicio,
                        principalTable: "exercicio",
                        principalColumn: "IdExercicio");
                    table.ForeignKey(
                        name: "FK_rotinaExercicio_exercicio_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "exercicio",
                        principalColumn: "IdExercicio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rotinaExercicio_rotina_IdRotina",
                        column: x => x.IdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rotinaExercicio_rotina_RotinaIdRotina",
                        column: x => x.RotinaIdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina");
                });

            migrationBuilder.CreateIndex(
                name: "IX_notificacao_IdRotina",
                table: "notificacao",
                column: "IdRotina");

            migrationBuilder.CreateIndex(
                name: "IX_notificacao_RotinaIdRotina",
                table: "notificacao",
                column: "RotinaIdRotina");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaDiaSemana_DiaSemanaIdDiaSemana",
                table: "rotinaDiaSemana",
                column: "DiaSemanaIdDiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaDiaSemana_IdDiaSemana",
                table: "rotinaDiaSemana",
                column: "IdDiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaDiaSemana_RotinaIdRotina",
                table: "rotinaDiaSemana",
                column: "RotinaIdRotina");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaExercicio_ExercicioIdExercicio",
                table: "rotinaExercicio",
                column: "ExercicioIdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaExercicio_IdExercicio",
                table: "rotinaExercicio",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaExercicio_RotinaIdRotina",
                table: "rotinaExercicio",
                column: "RotinaIdRotina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notificacao");

            migrationBuilder.DropTable(
                name: "rotinaDiaSemana");

            migrationBuilder.DropTable(
                name: "rotinaExercicio");

            migrationBuilder.AlterColumn<int>(
                name: "Intervalo",
                table: "rotina",
                type: "int",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);
        }
    }
}
