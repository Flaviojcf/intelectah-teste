using intelectah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace intelectah.Infrastructure.Persistance
{
    public class IntelectahDbContext(DbContextOptions<IntelectahDbContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Concessionaria> Concessionaria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
