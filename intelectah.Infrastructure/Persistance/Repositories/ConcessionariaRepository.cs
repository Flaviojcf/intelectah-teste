using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class ConcessionariaRepository : IConcessionariaRepository
    {
        public Task CreateAsync(Concessionaria entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Concessionaria>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Concessionaria> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
