using Locadora.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloTaxas
{
    public class MapeadorTaxas : IEntityTypeConfiguration<Taxas>
    {

        public void Configure(EntityTypeBuilder<Taxas> builder)
        {
            builder.ToTable("TBTaxas");
            
            builder.Property(t => t.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            builder.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(t => t.Valor).HasColumnName("Valor").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.TipoCobranca).HasColumnName("TipoCobranca").HasColumnType("int").IsRequired();
        }
    }
}
