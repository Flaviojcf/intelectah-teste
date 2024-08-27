using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        public Task CreateAsync(Venda entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Venda>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Venda> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
