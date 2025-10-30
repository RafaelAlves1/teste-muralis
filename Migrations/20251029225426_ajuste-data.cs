using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Migrations
{
    /// <inheritdoc />
    public partial class ajustedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(string),
                oldType: "nvarchar(23)",
                oldMaxLength: 23,
                oldDefaultValueSql: "FORMAT(GETDATE(), 'dd/MM/yyyy HH:mm:ss')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataCadastro",
                table: "Cliente",
                type: "nvarchar(23)",
                maxLength: 23,
                nullable: false,
                defaultValueSql: "FORMAT(GETDATE(), 'dd/MM/yyyy HH:mm:ss')",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
