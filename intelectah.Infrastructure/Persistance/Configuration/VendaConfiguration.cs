using intelectah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace intelectah.Infrastructure.Persistance.Configuration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(v => v.DataVenda)
                .IsRequired();

            builder.Property(v => v.PrecoVenda)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(v => v.ProtocoloVenda)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(v => v.Veiculo)
                .WithMany(veiculo => veiculo.Vendas)
                .HasForeignKey(v => v.VeiculoID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Concessionaria)
                .WithMany(concessionaria => concessionaria.Vendas)
                .HasForeignKey(v => v.ConcessionariaID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Cliente)
                .WithMany(cliente => cliente.Vendas)
                .HasForeignKey(v => v.ClienteID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
