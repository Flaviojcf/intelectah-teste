using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ConcessionariaQueries.GetAllConcessionarias
{
    public class GetAllConcessionariasQuery : IRequest<List<Concessionaria>>
    {
    }
}
