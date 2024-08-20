using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetFabricanteByName
{
    public class GetFabricanteByNameQueryHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<GetFabricanteByNameQuery, Fabricante>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<Fabricante> Handle(GetFabricanteByNameQuery request, CancellationToken cancellationToken)
        {
            return await _fabricanteRepository.GetByNameAsync(request.Nome);
        }
    }
}
