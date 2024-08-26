using intelectah.Domain.Entities;
using intelectah.Domain.Exceptions;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetFabricanteById
{
    public class GetFabricanteByIdQueryHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<GetFabricanteByIdQuery, Fabricante>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<Fabricante> Handle(GetFabricanteByIdQuery request, CancellationToken cancellationToken)
        {
            var fabricante = await _fabricanteRepository.GetByIdAsync(request.Id);

            if (fabricante == null)
            {
                throw new FabricanteNotFoundException(request.Id);
            }

            return fabricante;
        }
    }
}