using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    TipoCadastroCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBConfiguracaoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorGasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAlcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConfiguracaoCombustivel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoVeiculos",
                columns: table => new
                {
                    @int = table.Column<int>(name: "int", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    varchar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoVeiculos", x => x.@int);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCobranca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteCondutor = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(20)", nullable: false),
                    ValidadeCNH = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutores_TBClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "TBVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "int", nullable: false),
                    GrupoVeiculosId = table.Column<int>(type: "int", nullable: false),
                    Fotos = table.Column<byte[]>(type: "varbinary(max)", nullable: false, defaultValue: new byte[0]),
                    Alugado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculos_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "int",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBAlugueis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    CombustivelId = table.Column<int>(type: "int", nullable: false),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
                    MarcadorCombustivel = table.Column<int>(type: "int", nullable: false),
                    KmPercorrido = table.Column<int>(type: "int", nullable: false),
                    DataAluguel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevistaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAlugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAlugueis_TBCondutores_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAlugueis_TBConfiguracaoCombustivel_CombustivelId",
                        column: x => x.CombustivelId,
                        principalTable: "TBConfiguracaoCombustivel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAlugueis_TBVeiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBAlugueisTaxas",
                columns: table => new
                {
                    LocacoesId = table.Column<int>(type: "int", nullable: false),
                    TaxasSelecionadasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAlugueisTaxas", x => new { x.LocacoesId, x.TaxasSelecionadasId });
                    table.ForeignKey(
                        name: "FK_TBAlugueisTaxas_TBAlugueis_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBAlugueis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAlugueisTaxas_TBTaxas_TaxasSelecionadasId",
                        column: x => x.TaxasSelecionadasId,
                        principalTable: "TBTaxas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAlugueis_CombustivelId",
                table: "TBAlugueis",
                column: "CombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAlugueis_CondutorId",
                table: "TBAlugueis",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAlugueis_VeiculoId",
                table: "TBAlugueis",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAlugueisTaxas_TaxasSelecionadasId",
                table: "TBAlugueisTaxas",
                column: "TaxasSelecionadasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutores_ClienteId",
                table: "TBCondutores",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobrancas_GrupoVeiculosId",
                table: "TBPlanoCobrancas",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculos_GrupoVeiculosId",
                table: "TBVeiculos",
                column: "GrupoVeiculosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAlugueisTaxas");

            migrationBuilder.DropTable(
                name: "TBPlanoCobrancas");

            migrationBuilder.DropTable(
                name: "TBAlugueis");

            migrationBuilder.DropTable(
                name: "TBTaxas");

            migrationBuilder.DropTable(
                name: "TBCondutores");

            migrationBuilder.DropTable(
                name: "TBConfiguracaoCombustivel");

            migrationBuilder.DropTable(
                name: "TBVeiculos");

            migrationBuilder.DropTable(
                name: "TBClientes");

            migrationBuilder.DropTable(
                name: "TBGrupoVeiculos");
        }
    }
}
