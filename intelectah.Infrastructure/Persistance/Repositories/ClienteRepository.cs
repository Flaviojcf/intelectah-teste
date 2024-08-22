using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public Task CreateAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
