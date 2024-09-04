using Locadora.Dominio.ModuloAlugueis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloAlugueis
{
    public class MapeadorLocacao : IEntityTypeConfiguration<Alugueis>
    {
        public void Configure(EntityTypeBuilder<Alugueis> builder)
        {
                        builder.ToTable("TBAlugueis");

            builder.Property(l => l.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.TipoPlano)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.MarcadorCombustivel)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.KmPercorrido)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.DataAluguel)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(l => l.DataPrevistaDevolucao)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(l => l.DataDevolucao)
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(l => l.VeiculoId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Veiculo)
                .WithMany()
                .HasForeignKey(l => l.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(l => l.CondutorId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Condutor)
                .WithMany()
                .HasForeignKey(l => l.CondutorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(l => l.CombustivelId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Combustiveis)
                .WithMany()
                .HasForeignKey(l => l.CombustivelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.TaxasSelecionadas)
                .WithMany(t => t.Locacoes)
                .UsingEntity(j => j.ToTable("TBAlugueisTaxas"));
        }
    }
}