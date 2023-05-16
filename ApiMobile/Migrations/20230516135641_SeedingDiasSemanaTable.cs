using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDiasSemanaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 7, "Sábado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "dia_semana",
                keyColumn: "IdDiaSemana",
                keyValue: 7);
        }
    }
}
