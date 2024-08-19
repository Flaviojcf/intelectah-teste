using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ConcessionariaQueries.GetAllConcessionarias
{
    public class GetAllConcessionariasQueryHandler(IConcessionariaRepository concessionariaRepository) : IRequestHandler<GetAllConcessionariasQuery, List<Concessionaria>>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;
        public async Task<List<Concessionaria>> Handle(GetAllConcessionariasQuery request, CancellationToken cancellationToken)
        {
            return await _concessionariaRepository.GetAllAsync();
        }
    }
}
