using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetFabricanteById
{
    public class GetFabricanteByIdQuery(int id) : IRequest<Fabricante>
    {
        public int Id { get; set; } = id;
    }
}
