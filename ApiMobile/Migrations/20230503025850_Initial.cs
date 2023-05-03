using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UfCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocupacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdMedico = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaEncriptada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsuario);
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
                name: "IX_tipo_lesao_IdMedico",
                table: "tipo_lesao",
                column: "IdMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conteudo");

            migrationBuilder.DropTable(
                name: "dia_semana");

            migrationBuilder.DropTable(
                name: "exercicio");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "tipo_lesao");

            migrationBuilder.DropTable(
                name: "medico");
        }
    }
}
