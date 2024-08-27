using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.VendaQueries.GetAllVendas
{
    public class GetAllVendasQueryHandler(IVendaRepository vendaRepository) : IRequestHandler<GetAllVendasQuery, List<Venda>>
    {
        private readonly IVendaRepository _vendaRepository = vendaRepository;
        public async Task<List<Venda>> Handle(GetAllVendasQuery request, CancellationToken cancellationToken)
        {
            return await _vendaRepository.GetAllAsync();
        }
    }
}
