using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetFabricanteById
{
    public class GetFabricanteByIdQueryHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<GetFabricanteByIdQuery, Fabricante>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<Fabricante> Handle(GetFabricanteByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fabricanteRepository.GetByIdAsync(request.Id);
        }
    }
}
