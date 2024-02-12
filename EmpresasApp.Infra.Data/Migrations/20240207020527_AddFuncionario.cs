using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MATRICULA = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DATAADMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMPRESAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_EMPRESA_EMPRESAID",
                        column: x => x.EMPRESAID,
                        principalTable: "EMPRESA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_CPF",
                table: "FUNCIONARIO",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_EMPRESAID",
                table: "FUNCIONARIO",
                column: "EMPRESAID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_MATRICULA",
                table: "FUNCIONARIO",
                column: "MATRICULA",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FUNCIONARIO");
        }
    }
}
