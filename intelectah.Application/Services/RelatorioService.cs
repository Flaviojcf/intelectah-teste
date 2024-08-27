using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Records;
using intelectah.Domain.Repositories;

namespace intelectah.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IVendaRepository _vendaRepository;

        public RelatorioService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<List<VendaMensalRecord>> GetVendasMensaisAsync()
        {
            return await _vendaRepository.GetVendasMensaisAsync();
        }
    }
}
