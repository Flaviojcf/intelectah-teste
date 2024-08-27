using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class VendaRepository(IntelectahDbContext dbContext) : IVendaRepository
    {
        private readonly IntelectahDbContext _dbContext = dbContext;

        public async Task CreateAsync(Venda venda)
        {
            await _dbContext.Venda.AddAsync(venda);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Venda>> GetAllAsync()
        {
            return await _dbContext.Venda
                .Include(v => v.Veiculo)
                .Include(v => v.Concessionaria)
                .Include(v => v.Cliente)
                .ToListAsync();
        }


        public async Task<Venda> GetByIdAsync(int id)
        {
            return await _dbContext.Venda.SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
