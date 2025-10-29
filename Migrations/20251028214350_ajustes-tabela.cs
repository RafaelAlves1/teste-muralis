using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Migrations
{
    /// <inheritdoc />
    public partial class ajustestabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_ClienteIdCliente",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteIdCliente",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ClienteIdCliente",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Contato_ClienteIdCliente",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Contato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteIdCliente",
                table: "Endereco",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteIdCliente",
                table: "Contato",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_ClienteIdCliente",
                table: "Contato",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteIdCliente",
                table: "Endereco",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
