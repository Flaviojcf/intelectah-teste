using intelectah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace intelectah.Infrastructure.Persistance.Configuration
{
    public class ConcessionariaConfiguration : IEntityTypeConfiguration<Concessionaria>
    {
        public void Configure(EntityTypeBuilder<Concessionaria> builder)
        {
            builder.ToTable("Concessionaria");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
             .IsRequired()
             .HasMaxLength(100);
            builder.HasIndex(c => c.Nome)
                .IsUnique();


            builder.Property(c => c.Endereco)
                .HasColumnType("VARCHAR(255)")
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(255);

            builder.Property(c => c.Cidade)
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Estado)
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.CEP)
                .HasColumnType("VARCHAR(10)")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Telefone)
                .HasColumnType("VARCHAR(15)")
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Email)
                .HasColumnType("VARCHAR(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CapacidadeMaximaVeiculos)
                .IsRequired();
        }
    }
}
