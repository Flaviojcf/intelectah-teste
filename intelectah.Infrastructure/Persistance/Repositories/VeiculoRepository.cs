using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public Task CreateAsync(Veiculo entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Veiculo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Veiculo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
