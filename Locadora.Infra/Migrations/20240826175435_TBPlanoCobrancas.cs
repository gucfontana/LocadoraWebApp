using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBPlanoCobrancas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobrancas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoVeiculosId = table.Column<int>(type: "int", nullable: false),
                    ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorKmDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorKmDiarioControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiarioControlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorKmExcedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiarioKmLivre = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobrancas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobrancas_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "int",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobrancas_GrupoVeiculosId",
                table: "TBPlanoCobrancas",
                column: "GrupoVeiculosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobrancas");
        }
    }
}
