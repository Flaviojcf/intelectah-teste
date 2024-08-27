using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.VendaQueries.GetAllVendas
{
    public class GetAllVendasQuery : IRequest<List<Venda>>
    {
    }
}
