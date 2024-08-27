using intelectah.Domain.Records;

namespace intelectah.Application.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<VendaMensalRecord>> GetVendasMensaisAsync();
    }
}
