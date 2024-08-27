using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class VeiculoRepository(IntelectahDbContext dbContext) : IVeiculoRepository
    {
        private readonly IntelectahDbContext _dbContext = dbContext;
        public async Task CreateAsync(Veiculo veiculo)
        {
            await _dbContext.Veiculo.AddAsync(veiculo);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> GetAllAsync()
        {
            return await _dbContext.Veiculo
                .Where(v => v.IsActive)
                .Include(v => v.Fabricante)
                .ToListAsync();
        }


        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _dbContext.Veiculo.SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
