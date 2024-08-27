using intelectah.Domain.Entities;

namespace intelectah.Domain.Repositories
{
    public interface IConcessionariaRepository : IBaseRepository<Concessionaria>
    {
        Task<Concessionaria> GetByNameAsync(string nome);
    }
}
