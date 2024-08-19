using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetAllVeiculos
{
    public class GetAllVeiculosQueryHandler(IVeiculoRepository veiculoRepository) : IRequestHandler<GetAllVeiculosQuery, List<Veiculo>>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        public async Task<List<Veiculo>> Handle(GetAllVeiculosQuery request, CancellationToken cancellationToken)
        {
            return await _veiculoRepository.GetAllAsync();
        }
    }
}
