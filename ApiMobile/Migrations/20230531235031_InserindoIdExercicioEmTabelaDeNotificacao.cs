using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    /// <inheritdoc />
    public partial class InserindoIdExercicioEmTabelaDeNotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Enviado",
                table: "notificacao",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "IdExercicio",
                table: "notificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_notificacao_IdExercicio",
                table: "notificacao",
                column: "IdExercicio");

            migrationBuilder.AddForeignKey(
                name: "FK_notificacao_exercicio_IdExercicio",
                table: "notificacao",
                column: "IdExercicio",
                principalTable: "exercicio",
                principalColumn: "IdExercicio",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notificacao_exercicio_IdExercicio",
                table: "notificacao");

            migrationBuilder.DropIndex(
                name: "IX_notificacao_IdExercicio",
                table: "notificacao");

            migrationBuilder.DropColumn(
                name: "IdExercicio",
                table: "notificacao");

            migrationBuilder.AlterColumn<bool>(
                name: "Enviado",
                table: "notificacao",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
