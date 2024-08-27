using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intelectah.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addConcessionariaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concessionaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(255)", unicode: false, maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CapacidadeMaximaVeiculos = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concessionaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProtocoloVenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeiculoID = table.Column<int>(type: "int", nullable: false),
                    ConcessionariaID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Concessionaria_ConcessionariaID",
                        column: x => x.ConcessionariaID,
                        principalTable: "Concessionaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concessionaria_Nome",
                table: "Concessionaria",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ConcessionariaID",
                table: "Venda",
                column: "ConcessionariaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Concessionaria");
        }
    }
}
