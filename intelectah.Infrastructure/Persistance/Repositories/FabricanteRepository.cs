using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class FabricanteRepository : IFabricanteRepository
    {
        public Task CreateAsync(Fabricante entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Fabricante>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Fabricante> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Fabricante> GetByNameAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
