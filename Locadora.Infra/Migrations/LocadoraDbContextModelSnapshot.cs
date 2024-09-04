﻿// <auto-generated />
using System;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locadora.Infra.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    partial class LocadoraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlugueisTaxas", b =>
                {
                    b.Property<int>("LocacoesId")
                        .HasColumnType("int");

                    b.Property<int>("TaxasSelecionadasId")
                        .HasColumnType("int");

                    b.HasKey("LocacoesId", "TaxasSelecionadasId");

                    b.HasIndex("TaxasSelecionadasId");

                    b.ToTable("TBAlugueisTaxas", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloAlugueis.Alugueis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CombustivelId")
                        .HasColumnType("int");

                    b.Property<int>("CondutorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAluguel")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("KmPercorrido")
                        .HasColumnType("int");

                    b.Property<int>("MarcadorCombustivel")
                        .HasColumnType("int");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CombustivelId");

                    b.HasIndex("CondutorId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TBAlugueis", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloClientes.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NumeroDocumento");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Rua");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Telefone");

                    b.Property<int>("TipoCadastroCliente")
                        .HasColumnType("int")
                        .HasColumnName("TipoCadastroCliente");

                    b.HasKey("Id");

                    b.ToTable("TBClientes", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloCombustiveis.Combustiveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorAlcool")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorDiesel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorGas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorGasolina")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TBConfiguracaoCombustivel", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloCondutores.Condutores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ClienteCondutor")
                        .HasColumnType("bit")
                        .HasColumnName("ClienteCondutor");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CNH");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CPF");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telefone");

                    b.Property<DateTime>("ValidadeCnh")
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidadeCNH");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBCondutores", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("varchar");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoVeiculos", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloPlanoCobrancas.PlanoCobrancas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoVeiculosId")
                        .HasColumnType("int")
                        .HasColumnName("GrupoVeiculosId");

                    b.Property<decimal>("ValorDiario")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorDiario");

                    b.Property<decimal>("ValorDiarioControlado")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorDiarioControlado");

                    b.Property<decimal>("ValorDiarioKmLivre")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorDiarioKmLivre");

                    b.Property<decimal>("ValorKmControlado")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorKmDiarioControlado");

                    b.Property<decimal>("ValorKmDiario")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorKmDiario");

                    b.Property<decimal>("ValorKmExcedido")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorKmExcedido");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TBPlanoCobrancas", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloTaxas.Taxas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.Property<int>("TipoCobranca")
                        .HasColumnType("int")
                        .HasColumnName("TipoCobranca");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("TBTaxas", (string)null);
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloVeiculos.Veiculos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alugado")
                        .HasColumnType("bit");

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("int")
                        .HasColumnName("CapacidadeTanque");

                    b.Property<byte[]>("Fotos")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(max)")
                        .HasDefaultValue(new byte[0])
                        .HasColumnName("Fotos");

                    b.Property<int>("GrupoVeiculosId")
                        .HasColumnType("int")
                        .HasColumnName("GrupoVeiculosId");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Modelo");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int")
                        .HasColumnName("TipoCombustivel");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TBVeiculos", (string)null);
                });

            modelBuilder.Entity("AlugueisTaxas", b =>
                {
                    b.HasOne("Locadora.Dominio.ModuloAlugueis.Alugueis", null)
                        .WithMany()
                        .HasForeignKey("LocacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora.Dominio.ModuloTaxas.Taxas", null)
                        .WithMany()
                        .HasForeignKey("TaxasSelecionadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloAlugueis.Alugueis", b =>
                {
                    b.HasOne("Locadora.Dominio.ModuloCombustiveis.Combustiveis", "Combustiveis")
                        .WithMany()
                        .HasForeignKey("CombustivelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Locadora.Dominio.ModuloCondutores.Condutores", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Locadora.Dominio.ModuloVeiculos.Veiculos", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Combustiveis");

                    b.Navigation("Condutor");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloCondutores.Condutores", b =>
                {
                    b.HasOne("Locadora.Dominio.ModuloClientes.Clientes", "Cliente")
                        .WithMany("Condutores")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloPlanoCobrancas.PlanoCobrancas", b =>
                {
                    b.HasOne("Locadora.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloVeiculos.Veiculos", b =>
                {
                    b.HasOne("Locadora.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany("Veiculos")
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloClientes.Clientes", b =>
                {
                    b.Navigation("Condutores");
                });

            modelBuilder.Entity("Locadora.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
