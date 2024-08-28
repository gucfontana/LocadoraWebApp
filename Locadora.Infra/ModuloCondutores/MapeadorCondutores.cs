using Locadora.Dominio.ModuloCondutores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloCondutores
{
    public class MapeadorCondutores : IEntityTypeConfiguration<Condutores>
    {

        public void Configure(EntityTypeBuilder<Condutores> builder)
        {
            builder.ToTable("TBCondutores");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(c => c.Cnh)
                .HasColumnName("CNH")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(c => c.ValidadeCnh)
                .HasColumnName("ValidadeCNH")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.ClienteCondutor)
                .HasColumnName("ClienteCondutor")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(c => c.ClienteId)
                .HasColumnName("ClienteId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Condutores)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
