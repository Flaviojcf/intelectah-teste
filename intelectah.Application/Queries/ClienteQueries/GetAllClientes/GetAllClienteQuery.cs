using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetAllClientes
{
    public class GetAllClienteQuery : IRequest<List<Cliente>>
    {
    }
}
