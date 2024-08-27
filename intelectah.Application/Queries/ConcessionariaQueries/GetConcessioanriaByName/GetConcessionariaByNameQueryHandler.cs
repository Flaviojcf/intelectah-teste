using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ConcessionariaQueries.GetConcessioanriaByName
{
    public class GetConcessionariaByNameQueryHandler(IConcessionariaRepository concessionariaRepository) : IRequestHandler<GetConcessionariaByNameQuery, Concessionaria>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;
        public async Task<Concessionaria> Handle(GetConcessionariaByNameQuery request, CancellationToken cancellationToken)
        {
            return await _concessionariaRepository.GetByNameAsync(request.Nome);
        }
    }
}
