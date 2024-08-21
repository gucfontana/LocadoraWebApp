using Locadora.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : IEntityTypeConfiguration<GrupoVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            builder.ToTable("TBGrupoVeiculos");

            builder.Property(g => g.Id)
                .HasColumnName("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(g => g.Nome)
                .HasColumnName("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
