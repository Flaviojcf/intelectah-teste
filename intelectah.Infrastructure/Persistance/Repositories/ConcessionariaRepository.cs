using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class ConcessionariaRepository(IntelectahDbContext dbContext) : IConcessionariaRepository
    {
        private readonly IntelectahDbContext _dbContext = dbContext;
        public async Task CreateAsync(Concessionaria concessionaria)
        {
            await _dbContext.Concessionaria.AddAsync(concessionaria);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Concessionaria>> GetAllAsync()
        {
            return await _dbContext.Concessionaria.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<Concessionaria> GetByIdAsync(int id)
        {
            return await _dbContext.Concessionaria.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Concessionaria> GetByNameAsync(string nome)
        {
            return await _dbContext.Concessionaria.SingleOrDefaultAsync(c => c.Nome == nome);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
