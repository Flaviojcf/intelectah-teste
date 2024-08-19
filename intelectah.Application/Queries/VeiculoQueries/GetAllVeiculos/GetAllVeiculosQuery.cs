using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetAllVeiculos
{
    public class GetAllVeiculosQuery : IRequest<List<Veiculo>>
    {
    }
}
