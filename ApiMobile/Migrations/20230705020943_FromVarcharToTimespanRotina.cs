using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class FromVarcharToTimespanRotina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Rotina
                ALTER COLUMN Intervalo TIME(0)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Rotina
                ALTER COLUMN Intervalo VARCHAR(MAX)
            ");
        }
    }
}
