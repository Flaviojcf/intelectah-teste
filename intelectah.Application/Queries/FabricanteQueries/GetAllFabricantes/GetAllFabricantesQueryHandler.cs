using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes
{
    public class GetAllFabricantesQueryHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<GetAllFabricantesQuery, List<Fabricante>>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<List<Fabricante>> Handle(GetAllFabricantesQuery request, CancellationToken cancellationToken)
        {
            return await _fabricanteRepository.GetAllAsync();
        }
    }
}
