using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<List<Cliente>>
    {
    }
}
