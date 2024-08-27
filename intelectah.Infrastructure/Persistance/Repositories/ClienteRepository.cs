using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class ClienteRepository(IntelectahDbContext dbContext) : IClienteRepository
    {
        private readonly IntelectahDbContext _dbContext = dbContext;
        public async Task CreateAsync(Cliente cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _dbContext.Cliente.Where(v => v.IsActive).ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _dbContext.Cliente.SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Cliente> GetClienteByCPF(string CPF)
        {
            return await _dbContext.Cliente.SingleOrDefaultAsync(c => c.CPF == CPF);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
