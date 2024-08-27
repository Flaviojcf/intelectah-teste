using intelectah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace intelectah.Infrastructure.Persistance.Configuration
{
    public class FabricanteConfiguration : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {

            builder.ToTable("Fabricante");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(f => f.Nome)
                .IsUnique();


            builder.Property(f => f.PaisOrigem)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.AnoFundacao)
                .IsRequired();


            builder.Property(f => f.Website)
                .HasMaxLength(255);
        }
    }
}
