using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ConcessionariaQueries.GetConcessionariaById
{
    public class GetConcessionariaByIdQueryHandler(IConcessionariaRepository concessionariaRepository) : IRequestHandler<GetConcessionariaByIdQuery, Concessionaria>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;


        public async Task<Concessionaria> Handle(GetConcessionariaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _concessionariaRepository.GetByIdAsync(request.Id);
        }
    }
}

