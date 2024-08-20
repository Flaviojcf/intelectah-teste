using intelectah.Domain.Entities;

namespace intelectah.Domain.Repositories
{
    public interface IFabricanteRepository : IBaseRepository<Fabricante>
    {
        Task<Fabricante> GetByNameAsync(string nome);
    }
}
