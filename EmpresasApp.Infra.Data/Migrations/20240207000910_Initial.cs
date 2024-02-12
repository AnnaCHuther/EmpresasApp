using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NOMEFANTASIA = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_CNPJ",
                table: "EMPRESA",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_RAZAOSOCIAL",
                table: "EMPRESA",
                column: "RAZAOSOCIAL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPRESA");
        }
    }
}
