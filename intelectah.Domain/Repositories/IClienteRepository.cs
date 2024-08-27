using intelectah.Domain.Entities;

namespace intelectah.Domain.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> GetClienteByCPF(string CPF);
    }
}
