using Locadora.Dominio.ModuloVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Locadora.Infra.ModuloVeiculos
{
    public class MapeadorVeiculos : IEntityTypeConfiguration<Veiculos>
    {
        public void Configure(EntityTypeBuilder<Veiculos> builder)
        {
            builder.ToTable("TBVeiculos");

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(v => v.Modelo)
                .HasColumnName("Modelo")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(v => v.Marca)
                .HasColumnName("Marca")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(v => v.TipoCombustivel)
                .HasColumnName("TipoCombustivel")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(v => v.CapacidadeTanque)
                .HasColumnName("CapacidadeTanque")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(v => v.Fotos)
                .HasColumnName("Fotos")
                .HasColumnType("varbinary(max)")
                .HasDefaultValue(Array.Empty<byte>());

            builder.Property(v => v.GrupoVeiculosId)
                .HasColumnName("GrupoVeiculosId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(v => v.GrupoVeiculos)
                .WithMany(g => g.Veiculos)
                .HasForeignKey(v => v.GrupoVeiculosId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}