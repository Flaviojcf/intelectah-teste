using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetVeiculosByFabricante
{
    public class GetVeiculoByFabricanteQueryHandler(IVeiculoRepository veiculoRepository) : IRequestHandler<GetVeiculosByFabricanteQuery, List<Veiculo>>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        public async Task<List<Veiculo>> Handle(GetVeiculosByFabricanteQuery request, CancellationToken cancellationToken)
        {
            return await _veiculoRepository.GetVeiculosByFabricanteId(request.FabricanteID);
        }
    }
}
