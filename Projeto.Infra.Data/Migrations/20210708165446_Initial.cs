using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(maxLength: 150, nullable: false),
                    Numero = table.Column<string>(maxLength: 15, nullable: false),
                    Complemento = table.Column<string>(maxLength: 50, nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Cep = table.Column<string>(maxLength: 10, nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cpf",
                table: "Cliente",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Cliente",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCliente_ClienteId",
                table: "EnderecoCliente",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoCliente");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
