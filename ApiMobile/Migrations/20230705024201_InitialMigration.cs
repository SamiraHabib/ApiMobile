using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dia_semana",
                columns: table => new
                {
                    IdDiaSemana = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dia_semana", x => x.IdDiaSemana);
                });

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UfCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoCrm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocupacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "tipo_lesao",
                columns: table => new
                {
                    IdTipoLesao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_lesao", x => x.IdTipoLesao);
                    table.ForeignKey(
                        name: "FK_tipo_lesao_medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rotina",
                columns: table => new
                {
                    IdRotina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HorarioFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Intervalo = table.Column<TimeSpan>(type: "time", nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rotina", x => x.IdRotina);
                    table.ForeignKey(
                        name: "FK_rotina_paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenhaEncriptada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdMedico = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_usuario_medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuario_paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conteudo",
                columns: table => new
                {
                    IdConteudo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdTipoLesao = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conteudo", x => x.IdConteudo);
                    table.ForeignKey(
                        name: "FK_conteudo_medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_conteudo_tipo_lesao_IdTipoLesao",
                        column: x => x.IdTipoLesao,
                        principalTable: "tipo_lesao",
                        principalColumn: "IdTipoLesao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercicio",
                columns: table => new
                {
                    IdExercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdTipoLesao = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrucoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedGif = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Precaucoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercicio", x => x.IdExercicio);
                    table.ForeignKey(
                        name: "FK_exercicio_medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exercicio_tipo_lesao_IdTipoLesao",
                        column: x => x.IdTipoLesao,
                        principalTable: "tipo_lesao",
                        principalColumn: "IdTipoLesao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rotinaDiaSemana",
                columns: table => new
                {
                    IdRotina = table.Column<int>(type: "int", nullable: false),
                    IdDiaSemana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rotinaDiaSemana", x => new { x.IdRotina, x.IdDiaSemana });
                    table.ForeignKey(
                        name: "FK_rotinaDiaSemana_dia_semana_IdDiaSemana",
                        column: x => x.IdDiaSemana,
                        principalTable: "dia_semana",
                        principalColumn: "IdDiaSemana",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rotinaDiaSemana_rotina_IdRotina",
                        column: x => x.IdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notificacao",
                columns: table => new
                {
                    IdNotificacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRotina = table.Column<int>(type: "int", nullable: false),
                    IdExercicio = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enviado = table.Column<bool>(type: "bit", nullable: true),
                    RotinaIdRotina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificacao", x => x.IdNotificacao);
                    table.ForeignKey(
                        name: "FK_notificacao_exercicio_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "exercicio",
                        principalColumn: "IdExercicio",
                        onDelete: ReferentialAction.Restrict);
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
                name: "rotinaExercicio",
                columns: table => new
                {
                    IdRotina = table.Column<int>(type: "int", nullable: false),
                    IdExercicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rotinaExercicio", x => new { x.IdRotina, x.IdExercicio });
                    table.ForeignKey(
                        name: "FK_rotinaExercicio_exercicio_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "exercicio",
                        principalColumn: "IdExercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rotinaExercicio_rotina_IdRotina",
                        column: x => x.IdRotina,
                        principalTable: "rotina",
                        principalColumn: "IdRotina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dia_semana",
                columns: new[] { "IdDiaSemana", "Nome" },
                values: new object[,]
                {
                    { 1, "Domingo" },
                    { 2, "Segunda-feira" },
                    { 3, "Terça-feira" },
                    { 4, "Quarta-feira" },
                    { 5, "Quinta-feira" },
                    { 6, "Sexta-feira" },
                    { 7, "S�bado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_conteudo_IdMedico",
                table: "conteudo",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_conteudo_IdTipoLesao",
                table: "conteudo",
                column: "IdTipoLesao");

            migrationBuilder.CreateIndex(
                name: "IX_exercicio_IdMedico",
                table: "exercicio",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_exercicio_IdTipoLesao",
                table: "exercicio",
                column: "IdTipoLesao");

            migrationBuilder.CreateIndex(
                name: "IX_notificacao_IdExercicio",
                table: "notificacao",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_notificacao_IdRotina",
                table: "notificacao",
                column: "IdRotina");

            migrationBuilder.CreateIndex(
                name: "IX_notificacao_RotinaIdRotina",
                table: "notificacao",
                column: "RotinaIdRotina");

            migrationBuilder.CreateIndex(
                name: "IX_rotina_IdPaciente",
                table: "rotina",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaDiaSemana_IdDiaSemana",
                table: "rotinaDiaSemana",
                column: "IdDiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_rotinaExercicio_IdExercicio",
                table: "rotinaExercicio",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_lesao_IdMedico",
                table: "tipo_lesao",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Email",
                table: "usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdMedico",
                table: "usuario",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdPaciente",
                table: "usuario",
                column: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conteudo");

            migrationBuilder.DropTable(
                name: "notificacao");

            migrationBuilder.DropTable(
                name: "rotinaDiaSemana");

            migrationBuilder.DropTable(
                name: "rotinaExercicio");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "dia_semana");

            migrationBuilder.DropTable(
                name: "exercicio");

            migrationBuilder.DropTable(
                name: "rotina");

            migrationBuilder.DropTable(
                name: "tipo_lesao");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "medico");
        }
    }
}
