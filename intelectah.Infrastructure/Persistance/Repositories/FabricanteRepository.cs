using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class FabricanteRepository(IntelectahDbContext dbContext) : IFabricanteRepository
    {
        private readonly IntelectahDbContext _dbContext = dbContext;

        public async Task CreateAsync(Fabricante fabricante)
        {
            await _dbContext.Fabricante.AddAsync(fabricante);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Fabricante>> GetAllAsync()
        {
            return await _dbContext.Fabricante.Where(f => f.IsActive).ToListAsync();
        }

        public async Task<Fabricante> GetByIdAsync(int id)
        {
            return await _dbContext.Fabricante.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fabricante> GetByNameAsync(string nome)
        {
            return await _dbContext.Fabricante.SingleOrDefaultAsync(f => f.Nome == nome);
        }

        public Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
