using intelectah.Domain.Entities;
using intelectah.Domain.Records;

namespace intelectah.Domain.Repositories
{
    public interface IVendaRepository : IBaseRepository<Venda>
    {
        Task<List<VendaMensalRecord>> GetVendasMensaisAsync();
    }
}
