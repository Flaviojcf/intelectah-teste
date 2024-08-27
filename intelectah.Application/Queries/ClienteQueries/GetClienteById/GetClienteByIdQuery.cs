using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetClienteById
{
    public class GetClienteByIdQuery(int id) : IRequest<Cliente>
    {
        public int Id { get; set; } = id;
    }
}
