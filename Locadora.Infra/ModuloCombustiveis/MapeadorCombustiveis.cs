using Locadora.Dominio.ModuloCombustiveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloCombustiveis
{
    public class MapeadorConfiguracaoCombustivel : IEntityTypeConfiguration<Combustiveis>
    {
        public void Configure(EntityTypeBuilder<Combustiveis> builder)
        {
            builder.ToTable("TBConfiguracaoCombustivel");

            builder.Property(c => c.DataCriacao)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.ValorGasolina)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.ValorGas)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.ValorDiesel)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.ValorAlcool)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
