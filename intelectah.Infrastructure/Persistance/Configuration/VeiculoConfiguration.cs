using intelectah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace intelectah.Infrastructure.Persistance.Configuration
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd();


            builder.Property(v => v.Modelo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.AnoFabricacao)
                .IsRequired();


            builder.Property(v => v.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");


            builder.Property(v => v.TipoVeiculo)
                .IsRequired()
                .HasConversion<int>();


            builder.Property(v => v.Descricao)
                .HasMaxLength(500);

            builder.HasOne(v => v.Fabricante)
                   .WithMany(f => f.Veiculos)
                   .HasForeignKey(v => v.FabricanteID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

        }
    }
}
