using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloPlanoCobrancas
{
    public class MapeadorPlanoCobrancas : IEntityTypeConfiguration<PlanoCobrancas>
    {
        public void Configure(EntityTypeBuilder<PlanoCobrancas> builder)
        {
            builder.ToTable("TBPlanoCobrancas");

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.ValorDiario)
                .HasColumnName("ValorDiario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ValorKmDiario)
                .HasColumnName("ValorKmDiario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ValorDiarioControlado)
                .HasColumnName("ValorDiarioControlado")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ValorKmControlado)
                .HasColumnName("ValorKmDiarioControlado")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ValorKmExcedido)
                .HasColumnName("ValorKmExcedido")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ValorDiarioKmLivre)
                .HasColumnName("ValorDiarioKmLivre")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.GrupoVeiculosId)
                .HasColumnName("GrupoVeiculosId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(p => p.GrupoVeiculos)
                .WithMany()
                .HasForeignKey(p => p.GrupoVeiculosId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
