using Locadora.Dominio.ModuloClientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloClientes
{
    public class MapeadorClientes : IEntityTypeConfiguration<Clientes>
    {

        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("TBClientes");

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();
            
            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .ValueGeneratedOnAdd()
                .IsRequired();
            
            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(15)")
                .IsRequired();
            
            builder.Property(c => c.TipoCadastroCliente)
                .HasColumnName("TipoCadastroCliente")
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(c => c.NumeroDocumento)
                .HasColumnName("NumeroDocumento")
                .HasColumnType("varchar(20)")
                .IsRequired();
            
            builder.Property(c => c.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(100)")
                .IsRequired();
                
            builder.Property(c => c.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(c => c.Cep)
                .HasColumnName("Cep")
                .HasColumnType("varchar(10)")
                .IsRequired();
            
            builder.Property(c => c.Rua)
                .HasColumnName("Rua")
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(c => c.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
