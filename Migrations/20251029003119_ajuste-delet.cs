using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Migrations
{
    /// <inheritdoc />
    public partial class ajustedelet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_IdCliente",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_IdCliente",
                table: "Endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_IdCliente",
                table: "Contato",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_IdCliente",
                table: "Endereco",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_IdCliente",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_IdCliente",
                table: "Endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_IdCliente",
                table: "Contato",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_IdCliente",
                table: "Endereco",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
