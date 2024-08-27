using intelectah.Domain.Entities;

namespace intelectah.Domain.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task<List<Veiculo>> GetVeiculosByFabricanteId(int fabricanteId);
    }
}
