using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE u
                SET u.Nome = m.Nome,
                    u.DataNascimento = m.DataNascimento
                FROM Usuario u
                INNER JOIN Medico m ON u.idMedico = m.idMedico");

            migrationBuilder.Sql(@"
                UPDATE u
                SET u.Nome = p.Nome
                FROM Usuario u
                INNER JOIN Paciente p ON u.idPaciente = p.idPaciente");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "paciente");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "paciente");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "medico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "paciente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "paciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "medico",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE p
                SET p.Nome = u.Nome,
                    p.DataNascimento = u.DataNascimento
                FROM Paciente p
                INNER JOIN Usuario u ON u.idPaciente = p.idPaciente");

            migrationBuilder.Sql(@"
                UPDATE m
                SET m.Nome = u.Nome,
                    m.DataNascimento = u.DataNascimento
                FROM Medico m
                INNER JOIN Usuario u ON u.idMedico = m.idMedico");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "usuario");
        }
    }
}
