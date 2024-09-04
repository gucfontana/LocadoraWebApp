using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBAlugueis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alugado",
                table: "TBVeiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "Id", nullable: false),
                    CombustivelId = table.Column<int>(type: "int", nullable: false),
                    CombustiveisId = table.Column<int>(type: "int", nullable: true),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
                    MarcadorCombustivel = table.Column<int>(type: "int", nullable: false),
                    KmPercorrido = table.Column<int>(type: "int", nullable: false),
                    DataAluguel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevistaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacoes_TBCondutores_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacoes_TBConfiguracaoCombustivel_CombustiveisId",
                        column: x => x.CombustiveisId,
                        principalTable: "TBConfiguracaoCombustivel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locacoes_TBVeiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlugueisTaxas",
                columns: table => new
                {
                    LocacoesId = table.Column<int>(type: "int", nullable: false),
                    TaxasSelecionadasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlugueisTaxas", x => new { x.LocacoesId, x.TaxasSelecionadasId });
                    table.ForeignKey(
                        name: "FK_AlugueisTaxas_Locacoes_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlugueisTaxas_TBTaxas_TaxasSelecionadasId",
                        column: x => x.TaxasSelecionadasId,
                        principalTable: "TBTaxas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlugueisTaxas_TaxasSelecionadasId",
                table: "AlugueisTaxas",
                column: "TaxasSelecionadasId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_CombustiveisId",
                table: "Locacoes",
                column: "CombustiveisId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_CondutorId",
                table: "Locacoes",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlugueisTaxas");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropColumn(
                name: "Alugado",
                table: "TBVeiculos");
        }
    }
}
