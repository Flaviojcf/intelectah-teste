using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ConcessionariaQueries.GetConcessionariaById
{
    public class GetConcessionariaByIdQuery(int id) : IRequest<Concessionaria>
    {
        public int Id { get; set; } = id;
    }
}
